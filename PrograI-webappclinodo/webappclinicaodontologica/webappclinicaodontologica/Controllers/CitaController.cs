using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;

namespace webappclinicaodontologica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CitaController(MyDbContext context)
        {
            _context = context;
        }

        // ================================
        // 🟦 LISTAR TODAS LAS CITAS
        // ================================
        [HttpGet]
        public async Task<IEnumerable<object>> GetCitas()
        {
            return await _context.Citas
                .Join(_context.Pacientes,
                    c => c.IdPaciente,
                    p => p.IdPaciente,
                    (c, p) => new {
                        c.IdCita,
                        Paciente = p.Nombre,
                        c.Doctor,
                        Fecha = c.Fecha.ToString("yyyy-MM-dd"),
                        Hora = c.Hora.ToString(@"hh\:mm"),
                        c.Motivo,
                        c.Estado
                    })
                .ToListAsync();
        }

        // ================================
        // 🟦 CITA POR ID
        // ================================
        [HttpGet("{id}")]
        public async Task<Cita> GetCita(int id)
        {
            return await _context.Citas.FindAsync(id);
        }

        // ================================
        // 🟦 HORAS DISPONIBLES
        // ================================
        [HttpGet("horas-disponibles/{fecha}")]
        public async Task<IEnumerable<string>> GetHorasDisponibles(DateTime fecha)
        {
            List<TimeSpan> horarios = new();

            for (int h = 8; h <= 17; h++)
            {
                horarios.Add(new TimeSpan(h, 0, 0));
                horarios.Add(new TimeSpan(h, 30, 0));
            }

            var ocupadas = await _context.Citas
                .Where(c => c.Fecha == fecha)
                .Select(c => c.Hora)
                .ToListAsync();

            return horarios
                .Where(h => !ocupadas.Contains(h))
                .Select(h => h.ToString(@"hh\:mm"))
                .ToList();
        }

        // ================================
        // 🟦 CITAS DEL DÍA (Recepcionista)
        // ================================
        [HttpGet("hoy")]
        public async Task<IActionResult> GetCitasDeHoy()
        {
            var hoy = DateTime.Today;

            var citasHoy = await _context.Citas
                .Where(c => c.Fecha.Date == hoy)
                .OrderBy(c => c.Hora)
                .Select(c => new
                {
                    c.IdCita,
                    Paciente = _context.Pacientes
                            .Where(p => p.IdPaciente == c.IdPaciente)
                            .Select(p => p.Nombre).FirstOrDefault(),
                    c.Doctor,
                    Fecha = c.Fecha.ToString("yyyy-MM-dd"),
                    Hora = c.Hora.ToString(@"hh\:mm"),
                    c.Motivo,
                    c.Estado
                })
                .ToListAsync();

            return Ok(citasHoy);
        }

        // ================================
        // 🟩 CITAS DEL DÍA (Doctor)
        // ================================
        [HttpGet("doctor/hoy")]
        public async Task<IActionResult> GetCitasDoctorHoy()
        {
            var hoy = DateTime.Today;

            var citas = await _context.Citas
                .Where(c => c.Fecha.Date == hoy)
                .OrderBy(c => c.Hora)
                .Select(c => new
                {
                    c.IdCita,
                    Paciente = _context.Pacientes
                            .Where(p => p.IdPaciente == c.IdPaciente)
                            .Select(p => p.Nombre).FirstOrDefault(),
                    c.Doctor,
                    Fecha = c.Fecha.ToString("yyyy-MM-dd"),
                    Hora = c.Hora.ToString(@"hh\:mm"),
                    c.Motivo,
                    c.Estado
                })
                .ToListAsync();

            return Ok(citas);
        }

        // ================================
        // 🟦 CAMBIAR ESTADO (Doctor)
        // ================================
        [HttpPut("estado/{id}")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] string nuevoEstado)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return NotFound();

            cita.Estado = nuevoEstado;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Estado actualizado correctamente." });
        }

        // ================================
        // 🟦 CREAR CITA
        // ================================
        [HttpPost]
        public async Task<IActionResult> Crear(Cita cita)
        {
            cita.Doctor = "Doctor General";
            cita.Estado = "Pendiente";

            bool existe = await _context.Citas.AnyAsync(c =>
                c.Fecha.Date == cita.Fecha.Date &&
                c.Hora == cita.Hora
            );

            if (existe)
                return BadRequest(new { mensaje = "La hora seleccionada ya está ocupada." });

            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Cita creada correctamente." });
        }

        // ================================
        // 🟦 EDITAR CITA
        // ================================
        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, Cita cita)
        {
            var citaBD = await _context.Citas.FindAsync(id);
            if (citaBD == null)
                return NotFound();

            bool existe = await _context.Citas.AnyAsync(c =>
                c.IdCita != id &&
                c.Fecha.Date == cita.Fecha.Date &&
                c.Hora == cita.Hora
            );

            if (existe)
                return BadRequest(new { mensaje = "La hora seleccionada ya está ocupada." });

            citaBD.IdPaciente = cita.IdPaciente;
            citaBD.Fecha = cita.Fecha;
            citaBD.Hora = cita.Hora;
            citaBD.Motivo = cita.Motivo;

            await _context.SaveChangesAsync();
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null)
                return NotFound();

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Cita eliminada." });
        }
    }
}
