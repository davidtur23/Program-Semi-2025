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
    public class TratamientosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TratamientosController(MyDbContext context)
        {
            _context = context;
        }

        // OBTENER TRATAMIENTOS POR PACIENTE
        [HttpGet("paciente/{id}")]
        public async Task<IActionResult> GetByPaciente(int id)
        {
            var lista = await _context.DetalleTratamiento
                .Where(t => t.IdPaciente == id)
                .OrderByDescending(t => t.FechaAplicacion)
                .ToListAsync();

            return Ok(lista);
        }

        // CREAR TRATAMIENTO (NO pide idTratamiento y lo fuerza a 0)
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] DetalleTratamiento d)
        {
            d.IdTratamiento = null;

            
            d.FechaAplicacion = DateTime.Now;

            _context.DetalleTratamiento.Add(d);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Detalle de tratamiento agregado correctamente" });
        }


        // EDITAR TRATAMIENTO
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] DetalleTratamiento t)
        {
            var existe = await _context.DetalleTratamiento.FindAsync(id);
            if (existe == null)
                return NotFound();

            existe.Observaciones = t.Observaciones;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Tratamiento actualizado" });
        }

        // ELIMINAR TRATAMIENTO
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var existe = await _context.DetalleTratamiento.FindAsync(id);
            if (existe == null)
                return NotFound();

            _context.DetalleTratamiento.Remove(existe);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tratamiento eliminado" });
        }
    }
}

