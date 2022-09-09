using Microsoft.AspNetCore.Mvc;
using Modelos.Models;
using PruebaDigitalWare.Data;
using PruebaDigitalWare.Models;

namespace Negocio.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : Controller
    {
        private readonly PruebaDbContext _db;

        public CategoryController(PruebaDbContext pruebaDbContext)
        {
            _db = pruebaDbContext;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _db.Category.ToList();

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();

            return Ok(category);
        }

        [HttpPut]
        public IActionResult EditCategory([FromBody] Category updateCategory)
        {
            var category = _db.Category.Find(updateCategory.id_category);

            if (category == null)
            {
                return NotFound();
            }

            category.name = updateCategory.name;

            _db.SaveChanges();

            return Ok(category);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var category = _db.Category.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            _db.Category.Remove(category);
            _db.SaveChanges();

            return Ok(category);
        }
    }
}
