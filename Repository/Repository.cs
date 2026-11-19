using Entities;
using Repository.Models;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
namespace Repository
{
    public class UserRepository : IUserRepository
    {        
        MyDataBaseContext db;
        private readonly int numberOfUsers=0;

        public UserRepository(MyDataBaseContext db)
        {
            this.db = db;
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "Dini", "Rubinshtein" };
        }
        public async void Post(User user)
        {
            
            user.Id = numberOfUsers + 1;
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
           
        }

        public async Task PostLogin(Login login)
        {
            var user = await db.Users.FindAsync(login.password,login.userName);
            //var userName = await db.Users.FindAsync(login.userName);
            if (user.Password == login.password && login.userName == user.Email)
            {
                return user;
            }

        }


        public async Task GetById(int id)
        {
            var user = await db.Users.FindAsync(id);
            
            return user;
        }
        // PUT api/<UsersController>/5


        public async Task Put(User user)
        {
            var userToUpdate = await db.Users.FindAsync(user.Id);
            if (userToUpdate != null) {
                db.Users.Entry(userToUpdate).CurrentValues.SetValues(user);
                await db.SaveChangesAsync();
                return user;
            }
            
               
        }
    }
}
