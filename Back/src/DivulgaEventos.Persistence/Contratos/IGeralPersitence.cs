using System.Threading.Tasks;
using DivulgaEventos.Domain;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface IGeralPersitence
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        Task<bool> SaveChanges();
    }
}