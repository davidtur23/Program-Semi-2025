using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;

namespace webappclinicaodontologica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PacienteController(MyDbContext context)
        {
            _context = context;
        }

        // LISTAR
        [HttpGet]
        public async Task<IEnumerable<Paciente>> GetPacientes()
        {
            return await _context.Pacientes.ToListAsync();
        }

        // OBTENER POR ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            if (p == null)
                return NotFound();

            return p;
        }

        // CREAR
        [HttpPost]
        public async Task<IActionResult> CrearPaciente([FromBody] Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Paciente registrado." });
        }

        // EDITAR
        [HttpPut("{id}")]
        public async Task<IActionResult> EditarPaciente(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.IdPaciente)
                return BadRequest();

            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Paciente actualizado." });
        }

        // ELIMINAR
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPaciente(int id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            if (p == null)
                return NotFound();

            _context.Pacientes.Remove(p);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Paciente eliminado." });
        }
    }
}
