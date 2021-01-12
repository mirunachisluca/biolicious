using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetByIdAsync(int id);
        Task<Pagination<ProductDTO>> GetProductsAsync(ProductSpecificationParams parameters);
        Task InsertAsync(Product product);
        Task DeleteAsync(int id);
        Task DeleteAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
