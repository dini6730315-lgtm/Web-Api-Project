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

      UserServices userService=new UserServices();
            
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "Dini", "Rubinshtein" };
        }


        
        [HttpPost]
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
        [HttpPost("check")]
        //public ActionResult<int> Check([FromBody] string password)
        //{
        //   //return userService.Check(password);
        //}
        [HttpGet("{id}")]
        public ActionResult<User> GetById([FromBody] int id)
        {
           return userService.GetById(id);
        }
        // PUT api/<UsersController>/5

        [HttpPut]
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

