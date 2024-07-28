using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAPI1.Models;

namespace WebApplicationAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product>
        {
            new Product  { Id=1, Name = "IPhone" , Description="It's phone" },
            new Product{ Id=2, Name="dress", Description="It's clothes"},
            new Product{ Id=3, Name="shoes", Description="It's clothes"},
        };
        [HttpGet]
        public IActionResult GetALL()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.Find(e => e.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var NewProduct = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };

            products.Add(NewProduct);
            return Ok(NewProduct);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product request)
        {
            var CurrentProduct = products.Find(e => e.Id == id);
            if(CurrentProduct == null)
            {
                return NotFound();
            }

            CurrentProduct.Name = request.Name;
            CurrentProduct.Description = request.Description;
            return Ok(CurrentProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(e => e.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return Ok();
        }
    }
}
