using Prueba_viamatica.Models.DTOs.Pelicula;
using Prueba_viamatica.Models.DTOs.PeliculaSala;

namespace Prueba_viamatica.Services.Interfaces
{
    public interface IPeliculaService
    {
        Task<List<CreatePeliculaDto>> GetAll();
        Task Create(CreatePeliculaDto dto);
        Task Update(int id, UpdatePeliculaDto dto);
        Task Delete(int id);

        Task<List<CreatePeliculaDto>> BuscarPorNombre(string nombre);
        Task<List<PeliculaSalaDto>> BuscarPorFecha(DateTime fecha);
        Task<string> EstadoSala(string nombreSala);
    }
}