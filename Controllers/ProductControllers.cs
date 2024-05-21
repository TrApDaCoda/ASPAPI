using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiDOTNetCore.DataAccess;
using TestApiDOTNetCore.Models;

namespace TestApiDOTNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public ProductController(ApplicationContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "User")]
        [HttpGet("Products")]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [Authorize(Roles = "User")]
        [HttpGet("Product/{id}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Products")]
        public IActionResult PostProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Products")]
        public IActionResult PutProduct([FromBody] Product product)
        {
            var result = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == product.Id);

            if (result == null)
            {
                return NotFound();
            }

            _context.Products.Update(product);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Products")]
        public IActionResult DeleteProduct([FromQuery] int id)
        {
            var deleteProduct = _context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (deleteProduct == null)
            {
                return NotFound();
            }

            _context.Products.Remove(deleteProduct);
            _context.SaveChanges();

            return Ok();
        }
    }
}
