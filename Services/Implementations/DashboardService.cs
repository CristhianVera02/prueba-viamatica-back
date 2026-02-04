using Microsoft.EntityFrameworkCore;
using Prueba_viamatica.Data;
using Prueba_viamatica.Models.DTOs.Dashboard;
using Prueba_viamatica.Services.Interfaces;

namespace Prueba_viamatica.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardResumenDto> GetResumenAsync()
        {
            return new DashboardResumenDto
            {
                TotalSalas = await _context.SalasCine.CountAsync(),
                SalasDisponibles = await _context.SalasCine.CountAsync(s => s.Estado),
                TotalPeliculas = await _context.Peliculas.CountAsync()
            };
        }
    }
}