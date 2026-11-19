using Entities;
using Repository.Models;

namespace Repository
{
    public interface IUserRepository
    {
        IEnumerable<string> Get();
        Task<User> GetById(int id);
        Task<User> Post(User user);
        Task<User> PostLogin(Login login);
        Task<User> Put(User user);
    }
}