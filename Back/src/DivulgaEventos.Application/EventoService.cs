using System;
using System.Threading.Tasks;
using DivulgaEventos.Application.Contratos;
using DivulgaEventos.Domain;
using DivulgaEventos.Persistence.Contratos;

namespace DivulgaEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersitence _geralPersistence;
        private readonly IEventoPersitence _eventoPersitence;

        public EventoService(IGeralPersitence geralPersitence, IEventoPersitence eventoPersitence)
        {
            _geralPersistence = geralPersitence;
            _eventoPersitence = eventoPersitence;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersitence.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = _eventoPersitence.GetEventoByIdAsync(eventoId, false);

                if (evento == null) return null;

                model.Id = evento.Id;

                _geralPersistence.Update<Evento>(model);

                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventoPersitence.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersitence.GetEventoByIdAsync(eventoId, false);

                if (evento == null) throw new Exception("Evento para delete não encontrado!");

                _geralPersistence.Delete<Evento>(evento);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersitence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersitence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersitence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}