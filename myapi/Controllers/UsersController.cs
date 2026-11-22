using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Text.Json;
using Zxcvbn;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIproj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {

        IUserService userService;
        public UsersController(IUserService _userServices)
        {
            userService = _userServices;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "Dini", "Rubinshtein" };
        }


        
        [HttpPost]
        //Which User is this? Entities has no User class (it is commented out in Class1.cs), so this line doesn't compile
        public ActionResult<User> Post([FromBody] User user)
        {
            user = userService.Post(user);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }
        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] Login login)
        {
           return userService.PostLogin(login);
           
        }
        //Where does the password check go? The check method is commented out, and this route sits on GetById. Zxcvbn is referenced: which password service should call it? It doesn't exist yet: where is it?
        [HttpPost("check")]
        //public ActionResult<int> Check([FromBody] string password)
        //{
        //   //return userService.Check(password);
        //}
        [HttpGet("{id}")]
        //Why [FromBody] on id? The id comes from the route ({id}). What should GetById return when no user has this id?
        public ActionResult<User> GetById([FromBody] int id)
        {
           return userService.GetById(id);
        }
        // PUT api/<UsersController>/5

        [HttpPut]
            //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
            public void Put([FromBody] User user)
            {
             userService.Put(user);    
        }

            //// DELETE api/<UsersController>/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
            //}
        }
    }

