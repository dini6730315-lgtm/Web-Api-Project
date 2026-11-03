using Entities;
//using Syncfusion.XForms.Android.Core;
using System.Text.Json;
using Repository;
namespace Services
    
{
    public class UserServices
    {
        UserRepository repository =new UserRepository();
        public IEnumerable<string> Get()
        {

           return repository.Get();
        }
        public User Post(User user)
        {
           return repository.Post(user);
           
        }

        public User PostLogin(Login login)
        {
          
           return repository.PostLogin(login);

        }


        public User GetById(int id)
        {
          return repository.GetById(id);
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
