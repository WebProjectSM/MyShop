using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserBL _bl;
        public UserController(IUserBL bl)
        {
            _bl = bl;
        }


        // GET: api/<HomeController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string password, string name)
        {

            User user = await _bl.getUser(password, name);
            if (user != null)
            {
                return StatusCode(200);

            }
            return StatusCode(204);

        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
           
            User user =await _bl.getUserById(id);
            if (user != null)
                return user;
            return null;

        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User value)
        {
           User user = await _bl.addUser(value);
            //return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            return user;

        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            _bl.update(id, userToUpdate);



        }
       
      

        // DELETE api/<HomeController>/50
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
