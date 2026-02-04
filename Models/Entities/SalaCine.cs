using System.ComponentModel.DataAnnotations;

namespace Prueba_viamatica.Models.Entities
{
    public class SalaCine
    {
        [Key]
        public int IdSala { get; set; }
        [Required]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<PeliculaSalaCine> PeliculasSalaCine { get; set; }
    }
}