using AutoMapper;
using csharp_apis_ef_cine.DTO;
using csharp_apis_ef_cine.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharp_apis_ef_cine.Controllers
{
    [ApiController]
    [Route("api/cine/genero")]
    public class GenerosController : Controller
    {
        private readonly DataContext db;
        private readonly IMapper mapper;
        public GenerosController(DataContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("GuardarTheGenero")]
        public async Task<ActionResult> GuardarGen(GeneroDTO dto)
        {
            var rs = mapper.Map<Genero>(dto);
            db.Add(rs);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("GuardarGenero")]
        public async Task<ActionResult> Guardar(GeneroDTO generoDTO)
        {
            var verificar = await db.Generos.AnyAsync(x => x.Name == generoDTO.Name);
            var genero = mapper.Map<Genero>(generoDTO);
            db.Add(genero);     
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpPost(Name = "GuardarGeneroVarios")]
        public async Task<ActionResult> GuardarVarios(GeneroDTO[] generoDTO)
        {
            var response = mapper.Map<Genero[]>(generoDTO);
            db.AddRange(response);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("ListarGeneros")]
        public async Task<ActionResult<IEnumerable<Genero>>> Listar()
        {
            var response = await db.Generos.Select(x => new {x.Name}).ToListAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("NuevaLista")]
        public async Task<ActionResult<IEnumerable<Genero>>> ListarGeneros()
        {
            var rs = await db.Generos.ToListAsync();
            return Ok(rs);
        }
        [HttpGet]
        [Route("NuevaListaParametros")]
        public async Task<ActionResult<IEnumerable<Genero>>> ListaConParametros()
        {
            var rs = await db.Generos.Select(x => new { x.Id, x.Name }).ToListAsync();
            return Ok(rs);
        }

        [HttpPut("{id:int}/Update")]
        public async Task<ActionResult> UpdateGenero(int id, GeneroDTO dto)
        {
            var response = mapper.Map<Genero>(dto);
            response.Id = id;
            db.Update(response);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}/delete")]
        public async Task<ActionResult> DeleteGenero(int id)
        {
            var response = await db.Generos.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (response == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
