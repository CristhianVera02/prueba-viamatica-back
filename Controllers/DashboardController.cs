using Microsoft.AspNetCore.Mvc;
using Prueba_viamatica.Services.Interfaces;

namespace Prueba_viamatica.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet("resumen")]
        public async Task<IActionResult> GetResumen()
        {
            var result = await _service.GetResumenAsync();
            return Ok(result);
        }
    }
}
