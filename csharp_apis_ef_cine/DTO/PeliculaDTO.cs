namespace csharp_apis_ef_cine.DTO
{
    public class PeliculaDTO
    {
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }


        public List<int> Generos { get; set; } = new List<int>();

        // SE INGRESA LA PELICULA Y SE ESCRIBE EL PERSONAJE
        public List<PeliculaActorDTO> PeliculasActores { get; set; }
            = new List<PeliculaActorDTO>();
    }
}
