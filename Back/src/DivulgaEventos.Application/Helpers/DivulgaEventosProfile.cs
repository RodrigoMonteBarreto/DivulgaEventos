using AutoMapper;
using DivulgaEventos.Application.Dtos;
using DivulgaEventos.Domain;

namespace DivulgaEventos.Application.Helpers
{
    public class DivulgaEventosProfile : Profile
    {
        public DivulgaEventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        }
    }
}