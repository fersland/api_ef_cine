namespace csharp_apis_ef_cine.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public string? Contenido { get; set; } = null!;
        public bool Recomendar { get; set; }

        // PROPIEDAD DE NAVEGACION
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;

    }
}
