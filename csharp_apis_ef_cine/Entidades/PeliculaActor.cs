namespace csharp_apis_ef_cine.Entidades
{
    public class PeliculaActor
    {
        // Llave llave primaria compuestalugar
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
        public string Personaje { get; set; } = null!;
        public int Orden { get; set; }
    }
}
