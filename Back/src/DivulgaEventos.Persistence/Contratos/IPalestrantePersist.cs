using System.Threading.Tasks;
using DivulgaEventos.Domain;
using DivulgaEventos.Persistence.Models;

namespace DivulgaEventos.Persistence.Contratos
{
   public interface IPalestrantePersist : IGeralPersitence
    {
        Task<PageList<Palestrante>> GetAllPalestrantesAsync(PageParams pageParams, bool includeEventos = false);
        Task<Palestrante> GetPalestranteByUserIdAsync(int userId, bool includeEventos = false);
    }
}