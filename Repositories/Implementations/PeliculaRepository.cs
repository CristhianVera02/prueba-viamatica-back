using Microsoft.EntityFrameworkCore;
using Prueba_viamatica.Data;
using Prueba_viamatica.Models.Entities;
using Prueba_viamatica.Repositories.Interfaces;

namespace Prueba_viamatica.Repositories.Implementations
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly AppDbContext _context;

        public PeliculaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> GetAllAsync()
            => await _context.Peliculas.ToListAsync();

        public async Task<Pelicula?> GetByIdAsync(int id)
            => await _context.Peliculas.FirstOrDefaultAsync(p => p.IdPelicula == id);

        public async Task AddAsync(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pelicula pelicula)
        {
            _context.Peliculas.Update(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pelicula = await GetByIdAsync(id);
            if (pelicula == null) return;

            pelicula.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pelicula>> BuscarPorNombreAsync(string nombre)
            => await _context.Peliculas
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();
    }
}
