namespace Prueba_viamatica.Models.DTOs.SalaCine
{
    public class SalaCineUpdateDto
    {
        public int IdSala { get; set; }
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }
    }
}