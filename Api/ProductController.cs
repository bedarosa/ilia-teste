using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Implementations;
using Repository.Interface;
using System.Security.AccessControl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = _productRepository.GetAll();
            return Ok(products);
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/Product
        [HttpPost]
        public ActionResult Post([FromBody] Product produto)
        {
            if (produto == null)
            {
                return BadRequest("Product is null.");
            }

            _productRepository.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product produto)
        {
            if (produto == null || produto.Id != id)
            {
                return BadRequest("Product is null or ID mismatch.");
            }

            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _productRepository.Update(produto);
            return NoContent();
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productRepository.Delete(id);
            return NoContent();
        }
    }
}
