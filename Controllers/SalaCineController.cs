using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_viamatica.Data;
using Prueba_viamatica.Models.DTOs.SalaCine;
using Prueba_viamatica.Models.Entities;

namespace Prueba_viamatica.Controllers
{
    [ApiController]
    [Route("api/salas")]
    public class SalaCineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalaCineController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalas()
        {
            var salas = await _context.SalasCine
                .Where(s => s.Estado)
                .ToListAsync();

            return Ok(salas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalaById(int id)
        {
            var sala = await _context.SalasCine
                .FirstOrDefaultAsync(s => s.IdSala == id && s.Estado);

            if (sala == null)
                return NotFound("Sala no encontrada");

            return Ok(sala);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSala([FromBody] SalaCineCreateDto dto)
        {
            var sala = new SalaCine
            {
                IdSala = dto.IdSala,
                Nombre = dto.Nombre,
                Estado = true
            };

            _context.SalasCine.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSalaById),
                new { id = sala.IdSala }, sala);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSala(int id,
            [FromBody] SalaCineUpdateDto dto)
        {
            var sala = await _context.SalasCine.FindAsync(id);

            if (sala == null)
                return NotFound("Sala no encontrada");

            sala.IdSala = dto.IdSala;
            sala.Nombre = dto.Nombre;
            sala.Estado = dto.Estado;

            await _context.SaveChangesAsync();
            return Ok(sala);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var sala = await _context.SalasCine.FindAsync(id);

            if (sala == null)
                return NotFound("Sala no encontrada");

            sala.Estado = false;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Pelicula eliminada correctamente" });
        }

        [HttpGet("buscar/{nombre}")]
        public async Task<IActionResult> BuscarSalaPorNombre(string nombre)
        {
            var sala = await _context.SalasCine
                .Include(s => s.PeliculasSalaCine)
                .ThenInclude(ps => ps.Pelicula)
                .FirstOrDefaultAsync(s =>
                    s.Nombre.ToLower() == nombre.ToLower()
                    && s.Estado);

            if (sala == null)
                return NotFound("Sala no encontrada");

            int totalPeliculas = sala.PeliculasSalaCine.Count;

            string mensaje = totalPeliculas switch
            {
                < 3 => "Sala disponible",
                >= 3 and <= 5 => $"Sala con {totalPeliculas} películas asignadas",
                > 5 => "Sala no disponible"
            };

            return Ok(new
            {
                sala.IdSala,
                sala.Nombre,
                TotalPeliculas = totalPeliculas,
                Mensaje = mensaje
            });
        }

        [HttpGet("disponibilidad-sp/{nombre}")]
        public async Task<IActionResult> ConsultarDisponibilidadSP(string nombre)
        {
            var resultado = await _context.SalaDisponibilidad
                .FromSqlRaw(
                    "EXEC sp_ConsultarDisponibilidadSala @NombreSala = {0}",
                    nombre)
                .ToListAsync();

            if (!resultado.Any())
                return NotFound("Sala no encontrada");

            return Ok(resultado.First());
        }
    }
}