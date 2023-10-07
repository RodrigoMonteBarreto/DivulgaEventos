using System.Threading.Tasks;
using DivulgaEventos.Domain;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface ILotePersitence
    {
        /// <summary>
        /// Método get retornará uma lista de Lotes por eventoId
        /// </summary>
        /// <param name="eventoId">Código chave da tabela Evento</param>
        /// <returns>Lista de Lotes</returns>
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);
        
        /// <summary>
        /// Método get que retornará apenas 1 Lote
        /// </summary>
        /// <param name="eventoId">Código chave da tabela Evento</param>
        /// <param name="id">Código chave da tabela Lote</param>
        /// <returns>Apenas 1 Lote</returns>
        Task<Lote> GetLoteByIdsAsync(int eventoId, int id );
    }
}