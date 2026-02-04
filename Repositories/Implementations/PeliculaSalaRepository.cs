using Microsoft.EntityFrameworkCore;
using Prueba_viamatica.Data;
using Prueba_viamatica.Models.Entities;
using Prueba_viamatica.Repositories.Interfaces;

namespace Prueba_viamatica.Repositories.Implementations
{
    public class PeliculaSalaRepository : IPeliculaSalaRepository
    {
        private readonly AppDbContext _context;

        public PeliculaSalaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PeliculaSalaCine>> BuscarPorFechaAsync(DateTime fecha)
        {
            return await _context.PeliculaSalaCine
                .Include(ps => ps.Pelicula)
                .Include(ps => ps.SalaCine)
                .Where(ps => ps.FechaPublicacion.Date == fecha.Date)
                .ToListAsync();
        }

        public async Task<int> ContarPeliculasPorSalaAsync(string nombreSala)
        {
            return await _context.PeliculaSalaCine
                .Include(ps => ps.SalaCine)
                .Where(ps => ps.SalaCine.Nombre == nombreSala)
                .CountAsync();
        }

        public async Task AddAsync(PeliculaSalaCine entity)
        {
            _context.PeliculaSalaCine.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}