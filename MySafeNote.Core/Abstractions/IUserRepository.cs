using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace MySafeNote.Core.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<User> GetUsersAsync(Expression<Func<User, bool>> predicate);
        //Task<User> GetUserByIdAsync();
        //Task<User> CreateUserAsync();
        //Task<User> ChangeUserByIdAsync();
        //Task<User> DeleteUserByIdAsync();
    }
}
