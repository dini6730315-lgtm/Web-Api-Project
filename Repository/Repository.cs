using Entities;
using System.Text.Json;

namespace Repository
{
    public class UserRepository
    {
        static string filePath = "file.txt";
        public IEnumerable<string> Get()
        {           
            return new string[] { "Dini", "Rubinshtein" };
        }
        public User Post( User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return user;
        }
       
        public User PostLogin( Login login)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.userName == login.userName && user.password == login.password)
                        return user;
                }
            }
            return null;
           

        }
      
        
        public User GetById( int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User newUser =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (newUser.id == id)
                        return newUser;
                }
            }
            return null;
        }
        // PUT api/<UsersController>/5


        public void Put(User user)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile; 
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User newuser =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (newuser.id == user.id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
}
