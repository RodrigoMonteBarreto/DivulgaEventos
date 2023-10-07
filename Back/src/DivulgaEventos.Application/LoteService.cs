using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DivulgaEventos.Application.Contratos;
using DivulgaEventos.Application.Dtos;
using DivulgaEventos.Domain;
using DivulgaEventos.Persistence.Contratos;

namespace DivulgaEventos.Application
{
    public class LoteService : ILoteService
    {
        private readonly IGeralPersitence _geralPersistence;
        private readonly ILotePersitence _lotePersitence;
        private readonly IMapper _mapper;

        public LoteService(IGeralPersitence geralPersitence, ILotePersitence lotePersitence, IMapper mapper)
        {
            _geralPersistence = geralPersitence;
            _lotePersitence = lotePersitence;
            _mapper = mapper;
        }

        public async Task AddLote(int eventoId, LoteDto model)
        {
            try
            {
                var lote = _mapper.Map<Lote>(model);
                lote.EventoId = eventoId;

                _geralPersistence.Add<Lote>(lote);

                await _geralPersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto[]> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _lotePersitence.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null) return null;

                foreach (var model in models)
                {

                    if (model.Id == 0)
                    {
                        await AddLote(eventoId, model);
                    }
                    else
                    {
                        var lote = lotes.FirstOrDefault(lote => lote.Id == model.Id);
                        model.EventoId = eventoId;

                        _mapper.Map(model, lote);

                        _geralPersistence.Update<Lote>(lote);

                        await _geralPersistence.SaveChangesAsync();

                    }
                }

                var loteRetorno = await _lotePersitence.GetLotesByEventoIdAsync(eventoId);

                return _mapper.Map<LoteDto[]>(loteRetorno);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<bool> DeleteLote(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersitence.GetLoteByIdsAsync(eventoId, loteId);

                if (lote == null) throw new Exception("Lote para delete não encontrado!");

                _geralPersistence.Delete<Lote>(lote);
                return await _geralPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId)
        {
            try
            {
                var lotes = await _lotePersitence.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null) return null;

                var retorno = _mapper.Map<LoteDto[]>(lotes);
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<LoteDto> GetLoteByIdsAsync(int eventoId, int loteId)
        {
            try
            {
                var lote = await _lotePersitence.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null) return null;

                var retorno = _mapper.Map<LoteDto>(lote);
                return retorno;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}