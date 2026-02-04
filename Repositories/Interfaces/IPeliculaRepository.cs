using Prueba_viamatica.Models.Entities;

namespace Prueba_viamatica.Repositories.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<List<Pelicula>> GetAllAsync();
        Task<Pelicula?> GetByIdAsync(int id);
        Task AddAsync(Pelicula pelicula);
        Task UpdateAsync(Pelicula pelicula);
        Task DeleteAsync(int id);
        Task<List<Pelicula>> BuscarPorNombreAsync(string nombre);
    }
}