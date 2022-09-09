using Microsoft.AspNetCore.Mvc;
using PruebaDigitalWare.Data;
using PruebaDigitalWare.Models;

namespace PruebaDigitalWare.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly PruebaDbContext pruebaDbContext;

        public ProductController(PruebaDbContext pruebaDbContext)
        {
            this.pruebaDbContext = pruebaDbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = this.pruebaDbContext.Product.ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            this.pruebaDbContext.Product.Add(product);
            this.pruebaDbContext.SaveChanges();

            return Ok(product);
        }
    }
}
