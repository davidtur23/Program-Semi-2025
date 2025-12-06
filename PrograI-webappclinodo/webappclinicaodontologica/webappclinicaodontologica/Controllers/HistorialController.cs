using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;

namespace webappclinicaodontologica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialController : ControllerBase
    {
        private readonly MyDbContext _context;

        public HistorialController(MyDbContext context)
        {
            _context = context;
        }

        // OBTENER HISTORIAL DE UN PACIENTE
        [HttpGet("paciente/{id}")]
        public async Task<IActionResult> GetHistorialPorPaciente(int id)
        {
            var historial = await _context.HistorialMedico
                .Where(h => h.IdPaciente == id)
                .OrderByDescending(h => h.FechaRegistro)
                .ToListAsync();

            return Ok(historial);
        }

        // CREAR REGISTRO
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] HistorialMedico h)
        {
            h.FechaRegistro = DateTime.Now;   

            _context.HistorialMedico.Add(h);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Historial agregado correctamente" });
        }


        // EDITAR REGISTRO
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] HistorialMedico h)
        {
            var existe = await _context.HistorialMedico.FindAsync(id);

            if (existe == null)
                return NotFound();

            existe.Diagnostico = h.Diagnostico;
            existe.TratamientoSugerido = h.TratamientoSugerido;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Historial actualizado correctamente" });
        }

        // ELIMINAR REGISTRO
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var existe = await _context.HistorialMedico.FindAsync(id);

            if (existe == null)
                return NotFound();

            _context.HistorialMedico.Remove(existe);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Historial eliminado" });
        }
    }
}
