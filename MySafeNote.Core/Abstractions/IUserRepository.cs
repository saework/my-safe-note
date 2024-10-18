using System.Threading.Tasks;

namespace MySafeNote.Core.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> CheckUserExists(string email); 
    }
}
