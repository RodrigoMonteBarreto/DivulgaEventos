using System;
using Microsoft.AspNetCore.Mvc;
using DivulgaEventos.Domain;
using System.Collections.Generic;
using System.Linq;
using DivulgaEventos.Persistence;
using System.Threading.Tasks;
using DivulgaEventos.Persistence.Contextos;
using DivulgaEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using DivulgaEventos.Application.Dtos;

namespace DivulgaEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LotesController : ControllerBase
    {
        private readonly ILoteService _loteService;
        public LotesController(ILoteService loteService)
        {
            _loteService = loteService;
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar lotes. Erro {ex.Message}");
            }
        }


        [HttpPut("{eventoId}")]
        public async Task<IActionResult> SaveLotes(int eventoId, LoteDto[] models)
        {
            try
            {
                var lotes = await _loteService.SaveLotes(eventoId, models);
                if (lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar lotes. Erro {ex.Message}");
            }
        }

        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.GetLoteByIdsAsync(eventoId, loteId);
                if (lote == null) return NoContent();

                return await _loteService.DeleteLote(lote.EventoId, lote.Id) ?
                    Ok(new { message = "Lote Deletado" }) :
                    throw new Exception("Ocorreu um problema não especifíco ao tentar deletar o Lote.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar lote. Erro {ex.Message}");
            }
        }
    }
}
