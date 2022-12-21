using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryBL _bl;
        public CategoryController(ICategoryBL bl)
        {
            _bl = bl;
        }
       

        // GET: api/<HomeController>
        [HttpGet]
       

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
           
            Category Category =await _bl.getCategoryById(id);
            if (Category != null)
                return Category;
            return null;

        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category value)
        {
           Category Category = await _bl.addCategory(value);
            //return CreatedAtAction(nameof(Get), new { id = Category.CategoryId }, Category);
            return Category;

        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category CategoryToUpdate)
        {
            _bl.update(id, CategoryToUpdate);



        }
       
      

        // DELETE api/<HomeController>/50
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
