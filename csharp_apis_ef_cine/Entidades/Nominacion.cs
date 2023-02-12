namespace csharp_apis_ef_cine.Entidades
{
    public class Nominacion
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        /** COLECCIONES DE DATOS CON ENTIDAD PELICULA **/
        // SE GENERA TABLA INTERMEDIA "NOMINACIONPELICULAS"
        public HashSet<Pelicula> Peliculas { get; set; } = new HashSet<Pelicula>();
        /** FIN COLECCIONES DE DATOS CON ENTIDAD PELICULA **/
    }
}