using System.ComponentModel.DataAnnotations;

namespace Prueba_viamatica.Models.Entities
{
    public class Pelicula
    {
        [Key]
        public int IdPelicula { get; set; }
        [Required]
        public string Nombre { get; set; }
        public float Duracion { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<PeliculaSalaCine> PeliculasSalaCine { get; set; }
    }
}