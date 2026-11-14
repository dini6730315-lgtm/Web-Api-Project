using Entities;

namespace Services
{
    //The file name should match the type: IUserServices.cs should be named IUserService.cs
    public interface IUserService
    {
        IEnumerable<string> Get();
        User GetById(int id);
        User Post(User user);
        User PostLogin(Login login);
        void Put(User user);
    }
}