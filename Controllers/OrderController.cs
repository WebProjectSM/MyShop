using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IOrderBL _bl;
        public OrderController(IOrderBL bl)
        {
            _bl = bl;
        }
       

        // GET: api/<HomeController>
        [HttpGet]
       

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
           
            Order Order =await _bl.getOrderById(id);
            if (Order != null)
                return Order;
            return null;

        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order value)
        {
           Order Order = await _bl.addOrder(value);
            //return CreatedAtAction(nameof(Get), new { id = Order.OrderId }, Order);
            return Order;

        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Order OrderToUpdate)
        {
            _bl.update(id, OrderToUpdate);



        }
       
      

        // DELETE api/<HomeController>/50
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
