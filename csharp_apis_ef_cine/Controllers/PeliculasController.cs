using AutoMapper;
using csharp_apis_ef_cine.DTO;
using csharp_apis_ef_cine.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_apis_ef_cine.Controllers
{
    [ApiController]
    [Route("api/cine/peliculas")]
    public class PeliculasController : Controller
    {
        private readonly DataContext db;
        private readonly IMapper mapper;

        public PeliculasController(DataContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(PeliculaDTO peliculaDTO)
        {
            var pelicula = mapper.Map<Pelicula>(peliculaDTO);

            // Si el genero ingresado es un genero existente
            if (pelicula.Generos is not null)
            {
                foreach(var genero in pelicula.Generos)
                {
                    db.Entry(genero).State = EntityState.Unchanged;
                }
            }

            if (pelicula.PeliculasActores is not null)
            {
                for (var i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }

            db.Add(pelicula);
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
