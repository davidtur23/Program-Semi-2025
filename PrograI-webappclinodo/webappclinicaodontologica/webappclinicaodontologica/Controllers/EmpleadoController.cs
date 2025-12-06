using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;
using webappclinicaodontologica.Models.DTO;

namespace webappclinicaodontologica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly MyDbContext _context;

        public EmpleadoController(MyDbContext context)
        {
            _context = context;
        }

        // GET TODOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> GetEmpleados()
        {
            var empleados = await _context.Empleados
                .Include(e => e.Rol)
                .Select(e => new EmpleadoDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Usuario = e.Usuario,
                    Contrasena = e.Contrasena,
                    IdRol = e.IdRol,
                    Estado = e.Estado,
                    NombreRol = e.Rol.RolNombre
                })
                .ToListAsync();

            return empleados;
        }


        // GET por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetEmpleado(int id)
        {
            var emp = await _context.Empleados
                .Include(e => e.Rol)
                .Where(e => e.IdEmpleado == id)
                .Select(e => new
                {
                    e.IdEmpleado,
                    e.Nombre,
                    e.Apellido,
                    e.Usuario,
                    e.Contrasena,
                    e.IdRol,
                    e.Estado,
                    NombreRol = e.Rol.RolNombre
                })
                .FirstOrDefaultAsync();

            if (emp == null)
                return NotFound();

            return Ok(emp);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] EmpleadoDTO dto)
        {
            if (dto == null)
                return BadRequest("Datos inválidos");

            var empleado = new Empleado
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Usuario = dto.Usuario,
                Contrasena = dto.Contrasena,
                IdRol = dto.IdRol,
                Estado = dto.Estado
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return Ok(empleado);
        }



        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarEmpleado(int id, [FromBody] EmpleadoDTO dto)
        {
            if (id != dto.IdEmpleado)
                return BadRequest("ID no coincide");

            var emp = await _context.Empleados.FindAsync(id);
            if (emp == null)
                return NotFound();

            emp.Nombre = dto.Nombre;
            emp.Apellido = dto.Apellido;
            emp.Usuario = dto.Usuario;
            emp.Contrasena = dto.Contrasena;
            emp.IdRol = dto.IdRol;
            emp.Estado = dto.Estado;

            await _context.SaveChangesAsync();

            return Ok(emp);
        }



        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var emp = await _context.Empleados.FindAsync(id);
            if (emp == null)
                return NotFound();

            _context.Empleados.Remove(emp);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Empleado eliminado" });
        }
    }

}
