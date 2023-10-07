using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Domain;
using Microsoft.EntityFrameworkCore;
using DivulgaEventos.Persistence.Contratos;
using DivulgaEventos.Persistence.Contextos;

namespace DivulgaEventos.Persistence
{
    public class LotePersistence : ILotePersitence
    {
        private readonly DivulgaEventosContext _context;

        public LotePersistence(DivulgaEventosContext context)
        {
            _context = context;
        }

        public async Task<Lote> GetLoteByIdsAsync(int eventoId, int id)
        {
            IQueryable<Lote> query = _context.Lotes;

            query = query
                    .AsNoTracking()
                    .Where(lote => lote.EventoId == eventoId 
                            && lote.Id == id);
            
            return await query.FirstOrDefaultAsync();
        }
        
        public async Task<Lote[]> GetLotesByEventoIdAsync(int eventoId)
        {
            IQueryable<Lote> query = _context.Lotes;

            query = query
                    .AsNoTracking()
                    .Where(lote => lote.EventoId == eventoId);
            
            return await query.ToArrayAsync();
        }
    }
}