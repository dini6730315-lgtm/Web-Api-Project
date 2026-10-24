using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        static string filePath = "file.txt";
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "Dini", "Rubinshtein" };
        }


        
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.id },
            user);
        }
        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] Login login)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    var userlogin = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (userlogin?.userName == login.userName && userlogin.password ==
                    login.password)
                        return userlogin;
                }
            }
            return NoContent();

        }
        [HttpGet("{id}")]
        public ActionResult<User> GetById([FromBody] int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User newUser =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (newUser.id == id)
                        return CreatedAtAction(nameof(GetById), new { id = newUser.id }, newUser);
                }
            }
            return NotFound();

        }
        // PUT api/<UsersController>/5

        [HttpPut]
            public void Put([FromBody] User user)
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

            //// DELETE api/<UsersController>/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }
    }

