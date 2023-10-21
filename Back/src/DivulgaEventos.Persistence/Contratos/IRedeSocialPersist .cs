using System.Threading.Tasks;
using DivulgaEventos.Domain;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface IRedeSocialPersist : IGeralPersitence
    {
        Task<RedeSocial> GetRedeSocialEventoByIdsAsync(int eventoId, int id);
        Task<RedeSocial> GetRedeSocialPalestranteByIdsAsync(int palestranteId, int id);
        Task<RedeSocial[]> GetAllByEventoIdAsync(int eventoId);
        Task<RedeSocial[]> GetAllByPalestranteIdAsync(int palestranteId);
    }
}