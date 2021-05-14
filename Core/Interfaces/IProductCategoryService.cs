using Core.DTOs;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDTO> GetProductCategoryAsync(int id);
        Task<IReadOnlyList<ProductCategoryDTO>> GetProductCategoriesAsync(string sort);
        Task InsertAsync(ProductCategory category);
        Task DeleteAsync(int id);
        Task DeleteAsync(ProductCategory category);
        Task UpdateAsync(ProductCategory category);
        Task DeleteSubcategoryAsync(int id);
        Task UpdateSubcategoryAsync(ProductSubcategory subcategory);
    }
}
