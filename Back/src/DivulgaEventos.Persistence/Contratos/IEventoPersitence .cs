using System.Threading.Tasks;
using DivulgaEventos.Domain;
using DivulgaEventos.Persistence.Models;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface IEventoPersitence
    {
        //Eventos
        Task<PageList<Evento>> GetAllEventosAsync(int userId, PageParams pageParams, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false);
    }
}