using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MySafeNote.Core.Abstractions;

namespace MySafeNote.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(DataContext context)// : base(context)
        {
        }

        public async Task<User> GetUsersAsync(Expression<Func<User, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
