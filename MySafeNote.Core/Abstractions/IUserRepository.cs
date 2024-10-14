using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace MySafeNote.Core.Abstractions
{
    public interface IUserRepository
    {
        Task<User> GetUsersAsync();
        Task<User> GetUserByIdAsync();
        Task<User> CreateUserAsync();
        Task<User> ChangeUserByIdAsync();
        Task<User> DeleteUserByIdAsync();
    }
}
