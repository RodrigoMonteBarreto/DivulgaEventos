using System.Threading.Tasks;
using DivulgaEventos.Domain;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface IPalestrantePersitence
    {
        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);

    }
}