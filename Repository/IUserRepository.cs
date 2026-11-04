using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        IEnumerable<string> Get();
        User GetById(int id);
        User Post(User user);
        User PostLogin(Login login);
        void Put(User user);
    }
}