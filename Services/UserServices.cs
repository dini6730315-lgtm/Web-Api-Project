using Entities;
//using Syncfusion.XForms.Android.Core;
using System.Text.Json;
using Repository;
using Repository.Models;
namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository repository;

        public UserService(IUserRepository userRepository)
        {
            repository = userRepository;
        }

        public IEnumerable<string> Get()
        {

            return repository.Get();
        }
        public  User Post(User user)
        {
            return repository.Post(user).Result;

        }

        public User PostLogin(Login login)
        {

            return repository.PostLogin(login).Result;

        }


        public User GetById(int id)
        {
            return repository.GetById(id).Result;
        }
        // PUT api/<UsersController>/5

        //public int Check( string password)
        //{
        //    //var results = Core.EvaluatePassword(password);
        //    //return results.Score;
        //}
        public void Put(User user)
        {
            repository.Put(user);
        }
    }
}
