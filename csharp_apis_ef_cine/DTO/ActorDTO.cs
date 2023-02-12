using System.ComponentModel.DataAnnotations;

namespace csharp_apis_ef_cine.DTO
{
    public class ActorDTO
    {
        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
