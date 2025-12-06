using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;

namespace webappclinicaodontologica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaReportesController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CitaReportesController(MyDbContext context)
        {
            _context = context;
        }

        // ================================
        // 🔵 REPORTE GENERAL (día, mes o año)
        // ================================
        [HttpGet("filtrar")]
        public async Task<IActionResult> Filtrar([FromQuery] string tipo, [FromQuery] DateTime fecha)
        {
            IQueryable<Cita> query = _context.Citas;

            switch (tipo.ToLower())
            {
                case "dia":
                    query = query.Where(c => c.Fecha.Date == fecha.Date);
                    break;

                case "mes":
                    query = query.Where(c => c.Fecha.Month == fecha.Month && c.Fecha.Year == fecha.Year);
                    break;

                case "anio":
                    query = query.Where(c => c.Fecha.Year == fecha.Year);
                    break;
            }

            var citas = await query
                .OrderBy(c => c.Hora)
                .Select(c => new
                {
                    c.IdCita,
                    Paciente = _context.Pacientes
                                .Where(p => p.IdPaciente == c.IdPaciente)
                                .Select(p => p.Nombre)
                                .FirstOrDefault(),
                    c.Doctor,
                    c.Fecha,
                    Hora = c.Hora.ToString(@"hh\:mm"),
                    c.Motivo,
                    c.Estado
                })
                .ToListAsync();

            return Ok(citas);
        }
    }
}
