using System.ComponentModel.DataAnnotations;

namespace csharp_apis_ef_cine.Entidades
{
    public class Genero
    {
        public int Id { get; set; }
        //[StringLength(maximumLength:150)]
        public string Name { get; set; } = null!;

        // UN GENERO LE CORRESPONDE A VARIAS PELICULAS Y UNA PELICULAS PUEDE TENER VARIOS GENEROS
        // RELACION MUCHOS A MUCHOS
        // DONDE LAS ENTIDADES DE PELICULA Y GENERO SERAN HASHSET
        // SE GENERA TABLA INTERMEDIA "GENEROPELICULA"
        public HashSet<Pelicula> Peliculas { get; set; } = new HashSet<Pelicula>();
    }
}