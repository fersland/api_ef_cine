using System.ComponentModel.DataAnnotations;

namespace csharp_apis_ef_cine.DTO
{
    public class GeneroDTO
    {
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
    }
}
