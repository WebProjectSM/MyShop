using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp.Controllers.wwwroot
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductBL _bl;
        public ProductController(IProductBL bl)
        {
            _bl = bl;
        }
       

        // GET: api/<HomeController>
        [HttpGet]
       

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
           
            Product Product =await _bl.getProductById(id);
            if (Product != null)
                return Product;
            return null;

        }

        // POST api/<HomeController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product value)
        {
           Product Product = await _bl.addProduct(value);
            //return CreatedAtAction(nameof(Get), new { id = Product.ProductId }, Product);
            return Product;

        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product ProductToUpdate)
        {
            _bl.update(id, ProductToUpdate);



        }
       
      

        // DELETE api/<HomeController>/50
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
