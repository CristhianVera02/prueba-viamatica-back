using System.ComponentModel.DataAnnotations;

namespace Prueba_viamatica.Models.Entities
{
    public class PeliculaSalaCine
    {
        [Key]
        public int IdPeliculaSala { get; set; }

        public int IdPelicula { get; set; }
        public Pelicula Pelicula { get; set; }

        public int IdSalaCine { get; set; }
        public SalaCine SalaCine { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFin { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}