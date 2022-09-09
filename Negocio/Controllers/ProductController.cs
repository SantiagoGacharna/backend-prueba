using Microsoft.AspNetCore.Mvc;
using PruebaDigitalWare.Data;
using PruebaDigitalWare.Models;

namespace PruebaDigitalWare.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly PruebaDbContext _db;

        public ProductController(PruebaDbContext pruebaDbContext)
        {
            _db = pruebaDbContext;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _db.Product.ToList();

            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _db.Product.Add(product);
            _db.SaveChanges();

            return Ok(product);
        }

        [HttpPut]
        public IActionResult EditProduct([FromBody] Product updateProduct)
        {
            var product = _db.Product.Find(updateProduct.id_product);

            if (product == null)
            {
                return NotFound();
            }

            product.category_id = updateProduct.category_id;
            product.name = updateProduct.name;
            product.description = updateProduct.description;
            product.price = updateProduct.price;
            product.inventory = updateProduct.inventory;

            _db.SaveChanges();

            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var product = _db.Product.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            _db.Product.Remove(product);
            _db.SaveChanges();

            return Ok(product);
        }
    }
}
