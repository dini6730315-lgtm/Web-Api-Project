using Entities;

namespace Services
{
    public interface IUserService
    {
        IEnumerable<string> Get();
        User GetById(int id);
        User Post(User user);
        User PostLogin(Login login);
        void Put(User user);
    }
}