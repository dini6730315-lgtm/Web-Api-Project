using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly.
        //A name that says what is inside, like Users.txt, is clearer than file.txt
        static readonly string filePath = "file.txt";
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
            //fix: The new user is read back with GetById, so CreatedAtAction points to it
            return CreatedAtAction(nameof(GetById), new { id = user.id },
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
        //fix: The id comes from the route ({id}), not from the body. With [FromBody], a GET request
        //(which has no body) was rejected with 415 Unsupported Media Type
        public ActionResult<User> GetById(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User newUser =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (newUser.id == id)
                        //fix: GET only reads, so it returns 200 Ok and not 201 Created
                        return Ok(newUser);
                }
            }
            return NotFound();

        }
        // PUT api/<UsersController>/5

        //PUT usually gets the id in the route (api/Users/{id}): add {id} to [HttpPut], take int id as a parameter,
        //look for the user with this id, and set user.id = id before saving.
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
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
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
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

