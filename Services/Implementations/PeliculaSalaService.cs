using Prueba_viamatica.Models.DTOs.PeliculaSala;
using Prueba_viamatica.Models.Entities;
using Prueba_viamatica.Repositories.Interfaces;
using Prueba_viamatica.Services.Interfaces;

namespace Prueba_viamatica.Services.Implementations
{
    public class PeliculaSalaService : IPeliculaSalaService
    {
        private readonly IPeliculaSalaRepository _repository;

        public PeliculaSalaService(IPeliculaSalaRepository repository)
        {
            _repository = repository;
        }

        public async Task AsignarPeliculaAsync(AsignarPeliculaSalaDto dto)
        {
            if (dto.FechaFin <= dto.FechaPublicacion)
                throw new Exception("La fecha fin debe ser mayor a la fecha de publicación");

            var entidad = new PeliculaSalaCine
            {
                IdPelicula = dto.IdPelicula,
                IdSalaCine = dto.IdSalaCine,
                FechaPublicacion = dto.FechaPublicacion,
                FechaFin = dto.FechaFin
            };

            await _repository.AddAsync(entidad);
        }

    }
}