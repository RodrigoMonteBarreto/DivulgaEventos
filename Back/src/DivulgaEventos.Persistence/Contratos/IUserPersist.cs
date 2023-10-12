using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Domain.Identity;

namespace DivulgaEventos.Persistence.Contratos
{
    public interface IUserPersist : IGeralPersitence
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}