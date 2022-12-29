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
        

        //public async Task<IEnumerable<Product>> Get()
        //{
        //    return await _bl.getAllProducts();

        //}
        
        [HttpGet]
        
        public async Task<List<Product>> Get([FromQuery]int position, [FromQuery]int skip,[FromQuery] string? desc, [FromQuery]int? minPrice,[FromQuery] int? maxPrice, [FromQuery]int?[] categories)
        {
            List<Product> products = await _bl.getProducts(position, skip, desc, minPrice, maxPrice, categories);
            return products;
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
           
            Product Product =await _bl.getProductById(id);
            if (Product != null)
                return Product;
            return null;

        }
        // GET api/<HomeController>/5
        
     
        

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
