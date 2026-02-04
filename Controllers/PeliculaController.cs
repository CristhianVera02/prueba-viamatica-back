using Microsoft.AspNetCore.Mvc;
using Prueba_viamatica.Models.DTOs.Pelicula;
using Prueba_viamatica.Services.Interfaces;

namespace Prueba_viamatica.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _service;

        public PeliculaController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
            => Ok(await _service.GetAll());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePeliculaDto dto)
        {
            await _service.Create(dto);
            return Ok(new { mensaje = "Película creada correctamente" });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] UpdatePeliculaDto dto)
        {
            await _service.Update(id, dto);
            return Ok("Película actualizada correctamente");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok(new { mensaje = "Pelicula eliminada correctamente" });
        }

        [HttpGet("buscar-nombre")]
        public async Task<IActionResult> BuscarPorNombre(string nombre)
            => Ok(await _service.BuscarPorNombre(nombre));

        [HttpGet("buscar-fecha")]
        public async Task<IActionResult> BuscarPorFecha(DateTime fecha)
            => Ok(await _service.BuscarPorFecha(fecha));

        [HttpGet("estado-sala")]
        public async Task<IActionResult> EstadoSala(string nombreSala)
            => Ok(await _service.EstadoSala(nombreSala));
    }
}
