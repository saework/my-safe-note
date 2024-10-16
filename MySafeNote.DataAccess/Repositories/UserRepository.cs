using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MySafeNote.Core;
using MySafeNote.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MySafeNote.DataAccess.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<bool> CheckUserExists(string email)
        {
            return await DbSet.AnyAsync(x => x.Email == email);
        }
    }
}
