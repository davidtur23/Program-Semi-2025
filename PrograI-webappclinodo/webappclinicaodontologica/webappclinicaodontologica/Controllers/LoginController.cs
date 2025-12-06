using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;
using webappclinicaodontologica.Models.ViewModels;

namespace webappclinicaodontologica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;

        public LoginController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            // Validar datos vacíos
            if (string.IsNullOrWhiteSpace(login.Usuario) ||
                string.IsNullOrWhiteSpace(login.Contrasena))
            {
                return BadRequest("Usuario o contraseña vacíos.");
            }

            // Buscar empleado en la base
            var empleado = await _context.Empleados
                .Include(e => e.Rol)
                .FirstOrDefaultAsync(e =>
                    e.Usuario == login.Usuario &&
                    e.Contrasena == login.Contrasena &&
                    e.IdRol == login.IdRol &&
                    e.Estado == "Activo");

            if (empleado == null)
                return Unauthorized("Datos incorrectos");

            // Panel de destino
            string panel = empleado.Rol.RolNombre switch
            {
                "Recepcionista" => "/views/recepcionista.html",
                "Doctor" => "/views/doctor.html",
                "Administrador" => "/views/administrador.html",
                _ => "/views/index.html"
            };

            // Respuesta correcta
            return Ok(new
            {
                mensaje = "Login exitoso",
                nombre = $"{empleado.Nombre} {empleado.Apellido}",
                rol = empleado.Rol.RolNombre,
                panel = panel
            });
        }
    }
}
