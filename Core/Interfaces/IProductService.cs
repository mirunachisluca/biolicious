using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetByIdAsync(int id);
        Task<ProductDTO> GetByUrlNameAsync(string urlName);
        Task<Pagination<ProductDTO>> GetProductsAsync(ProductSpecificationParams parameters);
        Task<IReadOnlyList<ProductDTO>> GetNewProductsAsync();
        Task InsertAsync(Product product);
        Task DeleteAsync(int id);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
