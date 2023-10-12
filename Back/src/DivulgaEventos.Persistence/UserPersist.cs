using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DivulgaEventos.Domain.Identity;
using DivulgaEventos.Persistence.Contextos;
using DivulgaEventos.Persistence.Contratos;

namespace DivulgaEventos.Persistence
{
    public class UserPersist : GeralPersistence, IUserPersist
    {
        private readonly DivulgaEventosContext _context;

        public UserPersist(DivulgaEventosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }
    }
}