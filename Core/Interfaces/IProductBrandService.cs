using Core.DTOs;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductBrandService
    {
        Task<ProductBrandDTO> GetProductBrandAsync(int id);
        Task<IReadOnlyList<ProductBrandDTO>> GetProductBrandsAsync(string sort);
        Task<IReadOnlyList<ProductBrandDTO>> GetProductBrandsForCategoryAsync(int categoryId, int subcategoryId);
        Task InsertAsync(ProductBrand brand);
        Task DeleteAsync(int id);
        Task DeleteAsync(ProductBrand brand);
        Task UpdateAsync(ProductBrand brand);
    }
}
