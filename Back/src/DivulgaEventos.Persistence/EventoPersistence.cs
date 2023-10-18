using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Domain;
using Microsoft.EntityFrameworkCore;
using DivulgaEventos.Persistence.Contratos;
using DivulgaEventos.Persistence.Contextos;
using DivulgaEventos.Persistence.Models;

namespace DivulgaEventos.Persistence
{
    public class EventoPersistence : IEventoPersitence
    {
        private readonly DivulgaEventosContext _context;

        public EventoPersistence(DivulgaEventosContext context)
        {
            _context = context;
        }

        public async Task<PageList<Evento>> GetAllEventosAsync(int userId,  PageParams pageParams, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                .Include(x => x.Lotes)
                                                .Include(x => x.RedesSociais);
            if (includePalestrantes)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking()
                         .Where(e => (e.Tema.ToLower().Contains(pageParams.Term.ToLower()) ||
                                      e.Local.ToLower().Contains(pageParams.Term.ToLower())) &&
                                     e.UserId == userId)
                         .OrderBy(e => e.Id);

            return await PageList<Evento>.CreateAsync(query, pageParams.PageNumber, pageParams.pageSize);
        }

        public async Task<Evento> GetEventoByIdAsync(int userId, int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                .Include(x => x.Lotes)
                                                .Include(x => x.RedesSociais);
            if (includePalestrantes)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                         .Where(x => x.Id == eventoId && x.UserId == userId);

            return await query.FirstOrDefaultAsync();
        }

    }
}