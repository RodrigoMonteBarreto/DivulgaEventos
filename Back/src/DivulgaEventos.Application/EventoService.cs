using System;
using System.Threading.Tasks;
using AutoMapper;
using DivulgaEventos.Application.Contratos;
using DivulgaEventos.Application.Dtos;
using DivulgaEventos.Domain;
using DivulgaEventos.Persistence.Contratos;

namespace DivulgaEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersitence _geralPersistence;
        private readonly IEventoPersitence _eventoPersitence;
        private readonly IMapper _mapper;

        public EventoService(IGeralPersitence geralPersitence, IEventoPersitence eventoPersitence, IMapper mapper)
        {
            _geralPersistence = geralPersitence;
            _eventoPersitence = eventoPersitence;
            _mapper = mapper;
        }

        public async Task<EventoDto> AddEventos(int userId, EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                evento.UserId = userId;

                _geralPersistence.Add<Evento>(evento);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    var retorno = await _eventoPersitence.GetEventoByIdAsync(userId, evento.Id, false);
                    return _mapper.Map<EventoDto>(retorno);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int userId, int eventoId, EventoDto model)
        {
            try
            {
                var evento = await _eventoPersitence.GetEventoByIdAsync(userId, eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;
                model.UserId = userId;
                
                _mapper.Map(model, evento);

                _geralPersistence.Update<Evento>(evento);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    var eventoRetorno = await _eventoPersitence.GetEventoByIdAsync(userId, evento.Id, false);

                    return _mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int userId, int eventoId)
        {
            try
            {
                var evento = await _eventoPersitence.GetEventoByIdAsync(userId, eventoId, false);

                if (evento == null) throw new Exception("Evento para delete não encontrado!");

                _geralPersistence.Delete<Evento>(evento);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(int userId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersitence.GetAllEventosAsync(userId, includePalestrantes);
                if (eventos == null) return null;

                var retorno = _mapper.Map<EventoDto[]>(eventos);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersitence.GetAllEventosByTemaAsync(userId, tema, includePalestrantes);
                if (eventos == null) return null;

                var retorno = _mapper.Map<EventoDto[]>(eventos);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventoPersitence.GetEventoByIdAsync(userId, eventoId, includePalestrantes);
                if (evento == null) return null;

                var retorno = _mapper.Map<EventoDto>(evento);
                return retorno;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}