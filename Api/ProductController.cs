using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Implementations;
using Repository.Interface;
using Services.Interface;
using System.Security.AccessControl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        // Injeta o serviço de produto no construtor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products); // Retorna a lista de produtos com status 200
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Retorna status 404 se o produto não for encontrado
            }
            return Ok(product); // Retorna o produto com status 200
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDTO createProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna status 400 se o modelo não for válido
            }

            await _productService.AddProductAsync(createProductDTO);

            // O ID do produto pode não estar disponível imediatamente após a criação,
            // então o CreatedAtAction pode ser ajustado de acordo com sua implementação.
            // Por exemplo, você pode retornar um status 201 com uma mensagem de sucesso.
            return StatusCode(201); // Retorna status 201 após a criação
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna status 400 se o modelo não for válido
            }

            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound(); // Retorna status 404 se o produto não for encontrado
            }

            await _productService.UpdateProductAsync(id, updateProductDTO);
            return NoContent(); // Retorna status 204 indicando sucesso sem conteúdo
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _productService.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound(); // Retorna status 404 se o produto não for encontrado
            }

            await _productService.DeleteProductAsync(id);
            return NoContent(); // Retorna status 204 após exclusão
        }
    }
}
