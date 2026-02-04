using Prueba_viamatica.Models.DTOs.Pelicula;
using Prueba_viamatica.Models.DTOs.PeliculaSala;
using Prueba_viamatica.Models.Entities;
using Prueba_viamatica.Repositories.Interfaces;
using Prueba_viamatica.Services.Interfaces;

namespace Prueba_viamatica.Services.Implementations
{
    public class PeliculaService : IPeliculaService
    {
        private readonly IPeliculaRepository _peliculaRepo;
        private readonly IPeliculaSalaRepository _peliculaSalaRepo;

        public PeliculaService(
            IPeliculaRepository peliculaRepo,
            IPeliculaSalaRepository peliculaSalaRepo)
        {
            _peliculaRepo = peliculaRepo;
            _peliculaSalaRepo = peliculaSalaRepo;
        }

        public async Task<List<CreatePeliculaDto>> GetAll()
        {
            var peliculas = await _peliculaRepo.GetAllAsync();

            return peliculas.Select(p => new CreatePeliculaDto
            {
                IdPelicula = p.IdPelicula,
                Nombre = p.Nombre,
                Duracion = p.Duracion
            }).ToList();
        }

        public async Task<List<CreatePeliculaDto>> BuscarPorNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Nombre requerido");

            var peliculas = await _peliculaRepo.BuscarPorNombreAsync(nombre);

            return peliculas.Select(p => new CreatePeliculaDto
            {
                Nombre = p.Nombre,
                Duracion = p.Duracion
            }).ToList();
        }

        public async Task<List<PeliculaSalaDto>> BuscarPorFecha(DateTime fecha)
        {
            if (fecha == default)
                throw new Exception("Fecha inválida");

            var registros = await _peliculaSalaRepo.BuscarPorFechaAsync(fecha);

            return registros.Select(r => new PeliculaSalaDto
            {
                Pelicula = r.Pelicula.Nombre,
                Sala = r.SalaCine.Nombre,
                FechaPublicacion = r.FechaPublicacion,
                FechaFin = r.FechaFin
            }).ToList();
        }

        public async Task<string> EstadoSala(string nombreSala)
        {
            if (string.IsNullOrWhiteSpace(nombreSala))
                throw new Exception("Nombre de sala requerido");

            int cantidad = await _peliculaSalaRepo.ContarPeliculasPorSalaAsync(nombreSala);

            if (cantidad < 3)
                return "Sala disponible";

            if (cantidad <= 5)
                return $"Sala con {cantidad} películas asignadas";

            return "Sala no disponible";
        }

        public async Task Create(CreatePeliculaDto dto)
        {
            var pelicula = new Pelicula
            {
                Nombre = dto.Nombre,
                Duracion = dto.Duracion
            };

            await _peliculaRepo.AddAsync(pelicula);
        }

        public async Task Update(int id, UpdatePeliculaDto dto)
        {
            var pelicula = await _peliculaRepo.GetByIdAsync(id);
            if (pelicula == null)
                throw new Exception("Película no encontrada");

            pelicula.Nombre = dto.Nombre;
            pelicula.Duracion = dto.Duracion;

            await _peliculaRepo.UpdateAsync(pelicula);
        }

        public async Task Delete(int id)
        {
            await _peliculaRepo.DeleteAsync(id);
        }
    }
}