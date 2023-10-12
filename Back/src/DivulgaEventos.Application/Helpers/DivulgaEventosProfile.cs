using AutoMapper;
using DivulgaEventos.Application.Dtos;
using DivulgaEventos.Domain;
using DivulgaEventos.Domain.Identity;

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

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}