using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Domain;
using Microsoft.EntityFrameworkCore;
using DivulgaEventos.Persistence.Contratos;
using DivulgaEventos.Persistence.Contextos;

namespace DivulgaEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersitence
    {
        private readonly DivulgaEventosContext _context;

        public PalestrantePersistence(DivulgaEventosContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                     .Include(x => x.RedesSociais);

            if (includeEventos)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Evento);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id);


            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                     .Include(x => x.RedesSociais);

            if (includeEventos)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Evento);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                         .Where(x => x.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                                     .Include(x => x.RedesSociais);

            if (includeEventos)
            {
                query = query
                        .Include(x => x.PalestrantesEventos)
                        .ThenInclude(x => x.Evento);
            }

            query = query.AsNoTracking().OrderBy(x => x.Id)
                         .Where(x => x.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}