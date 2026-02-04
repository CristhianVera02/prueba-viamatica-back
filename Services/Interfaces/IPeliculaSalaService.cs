using Prueba_viamatica.Models.DTOs.PeliculaSala;

namespace Prueba_viamatica.Services.Interfaces
{
    public interface IPeliculaSalaService
    {

        Task AsignarPeliculaAsync(AsignarPeliculaSalaDto dto);

    }
}