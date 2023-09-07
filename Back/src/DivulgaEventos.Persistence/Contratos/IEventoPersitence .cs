using System.Threading.Tasks;
using DivulgaEventos.Domain;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface IEventoPersitence
    {
        //Eventos
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}