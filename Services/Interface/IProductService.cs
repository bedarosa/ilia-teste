using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int id);
        Task AddProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(int id, UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(int id);
    }
}
