using Microsoft.AspNetCore.Mvc;
using Prueba_viamatica.Models.DTOs.PeliculaSala;
using Prueba_viamatica.Services.Interfaces;

namespace Prueba_viamatica.Controllers
{
    [ApiController]
    [Route("api/pelicula-sala")]
    public class PeliculaSalaController : ControllerBase
    {
        private readonly IPeliculaSalaService _service;

        public PeliculaSalaController(IPeliculaSalaService service)
        {
            _service = service;
        }

        [HttpPost("asignar")]
        public async Task<IActionResult> AsignarPelicula([FromBody] AsignarPeliculaSalaDto dto)
        {
            await _service.AsignarPeliculaAsync(dto);
            return Ok(new { mensaje = "Pelicula asociada correctamente" });
        }
    }
}
