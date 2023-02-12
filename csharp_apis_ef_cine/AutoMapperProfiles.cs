using AutoMapper;
using csharp_apis_ef_cine.DTO;
using csharp_apis_ef_cine.Entidades;

namespace csharp_apis_ef_cine
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroDTO, Genero>();
            CreateMap<ActorDTO, Actor>();

            CreateMap<PeliculaDTO, Pelicula>()
                .ForMember(ent => ent.Generos, dto => dto
                .MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));

            CreateMap<PeliculaActorDTO, PeliculaActor>();
        }
    }
}
