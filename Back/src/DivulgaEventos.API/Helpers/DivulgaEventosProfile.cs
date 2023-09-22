using AutoMapper;
using DivulgaEventos.API.Dtos;
using DivulgaEventos.Domain;

namespace DivulgaEventos.API.Helpers
{
    public class DivulgaEventosProfile : Profile
    {
        public DivulgaEventosProfile()
        {
            CreateMap<Evento, EventoDto>();
        }
    }
}