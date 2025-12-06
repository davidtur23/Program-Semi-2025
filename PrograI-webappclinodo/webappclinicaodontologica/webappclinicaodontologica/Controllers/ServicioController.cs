using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webappclinicaodontologica.Data;
using webappclinicaodontologica.Models;

[Route("api/[controller]")]
[ApiController]
public class ServicioController : ControllerBase
{
    private readonly MyDbContext _context;

    public ServicioController(MyDbContext context)
    {
        _context = context;
    }

    // GET: api/Servicio
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
    {
        return await _context.Servicios.ToListAsync();
    }

    // GET: api/Servicio/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Servicio>> GetServicio(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);

        if (servicio == null)
            return NotFound();

        return servicio;
    }

    // POST: api/Servicio
    [HttpPost]
    public async Task<ActionResult> PostServicio([FromForm] Servicio servicio)
    {
        if (servicio == null)
            return BadRequest("Datos inválidos");

        _context.Servicios.Add(servicio);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Servicio creado correctamente" });
    }

    // PUT: api/Servicio/5
    [HttpPut("{id}")]
    public async Task<ActionResult> PutServicio(int id, [FromForm] Servicio servicio)
    {
        if (id != servicio.IdServicio)
            return BadRequest("El ID no coincide");

        _context.Entry(servicio).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Servicio actualizado correctamente" });
    }

    // DELETE: api/Servicio/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteServicio(int id)
    {
        var servicio = await _context.Servicios.FindAsync(id);

        if (servicio == null)
            return NotFound();

        _context.Servicios.Remove(servicio);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Servicio eliminado" });
    }
}
