using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderService orderService;
        public OrderController(IOrderService _orderServices)
        {
            orderService = _orderServices;
        }
        // GET: api/<UsersController>
        [HttpGet]
     



        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            order = orderService.Post(order);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
