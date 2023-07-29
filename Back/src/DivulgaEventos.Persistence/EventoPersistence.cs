using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Domain;
using Microsoft.EntityFrameworkCore;
using DivulgaEventos.Persistence.Contratos;


namespace DivulgaEventos.Persistence
{
    public class EventoPersistence : IEventoPersitence
    {
        private readonly DivulgaEventosContext _context;

        public EventoPersistence(DivulgaEventosContext context)
        {
            _context = context;
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                .Include(x => x.Lote)
                                                .Include(x => x.RedesSociais);
            if (includePalestrantes)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
            }

            query = query.OrderBy(x => x.Id);

            return await query.ToArrayAsync();

        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                .Include(x => x.Lote)
                                                .Include(x => x.RedesSociais);
            if (includePalestrantes)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
            }

            query = query.OrderBy(x => x.Id)
                         .Where(x => x.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                                                .Include(x => x.Lote)
                                                .Include(x => x.RedesSociais);
            if (includePalestrantes)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Palestrante);
            }

            query = query.OrderBy(x => x.Id)
                         .Where(x => x.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}