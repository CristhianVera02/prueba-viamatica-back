namespace Prueba_viamatica.Models.DTOs.PeliculaSala
{
    public class AsignarPeliculaSalaDto
    {
        public int IdPelicula { get; set; }
        public int IdSalaCine { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFin { get; set; }
    }
}