using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Domain;
using Microsoft.EntityFrameworkCore;
using DivulgaEventos.Persistence.Contratos;
using DivulgaEventos.Persistence.Contextos;

namespace DivulgaEventos.Persistence
{
    public class EventoPersistence : IEventoPersitence
    {
        private readonly DivulgaEventosContext _context;

        public EventoPersistence(DivulgaEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(int userId, bool includePalestrantes = false)
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
                         .Where(e => e.UserId == userId)
                         .OrderBy(e => e.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(int userId, string tema, bool includePalestrantes = false)
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
                         .Where(e => e.Tema.ToLower().Contains(tema.ToLower()) &&
                                     e.UserId == userId);

            return await query.ToArrayAsync();
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