using Prueba_viamatica.Models.Entities;

namespace Prueba_viamatica.Repositories.Interfaces
{
    public interface IPeliculaSalaRepository
    {
        Task AddAsync(PeliculaSalaCine entidad);
        Task<List<PeliculaSalaCine>> BuscarPorFechaAsync(DateTime fecha);
        Task<int> ContarPeliculasPorSalaAsync(string nombreSala);
    }
}