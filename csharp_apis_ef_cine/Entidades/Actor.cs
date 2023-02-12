namespace csharp_apis_ef_cine.Entidades
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }

        // LISTADO DE PELICULASACTORES CON LAS ENTIDADES - ACTOR PELICULA
        public List<PeliculaActor> PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}