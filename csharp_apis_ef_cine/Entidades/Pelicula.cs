namespace csharp_apis_ef_cine.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }


        // COLECCIONES DE DATOS //
        // UNO A MUCHOS - PELICULA ES 1 | COMENTARIOS ES MUCHOS
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        
        // MUCHOS A MUCHOS - SE GENERA TABLA INTERMEDIA
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();
        public HashSet<Nominacion> Nominaciones { get; set; } = new HashSet<Nominacion>();

        // SOLO LISTAS
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}
