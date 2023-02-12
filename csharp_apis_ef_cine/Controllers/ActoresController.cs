using AutoMapper;
using csharp_apis_ef_cine.DTO;
using csharp_apis_ef_cine.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_apis_ef_cine.Controllers
{
    [ApiController]
    [Route("api/cine/actores")]
    public class ActoresController : Controller
    {
        private readonly DataContext db;
        private readonly IMapper mapper;

        public ActoresController(DataContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Guardar(ActorDTO actorDTO)
        {
            var verificar = await db.Actores.AnyAsync(x => x.Nombre == actorDTO.Nombre);
            if (verificar)
            {
                return BadRequest("Este actor ya se ha registrado anteriormente: " + actorDTO.Nombre);
            }

            var results = mapper.Map<Actor>(actorDTO);
            db.Add(results);
            await db.SaveChangesAsync();
            return Ok();
        }

    }
}
