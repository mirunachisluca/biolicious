using Core.DTOs;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRecipeCategoryService
    {
        Task<RecipeCategoryDTO> GetByIdAsync(int id);
        Task<IReadOnlyList<RecipeCategoryDTO>> GetRecipeCategoriesAsync();
        Task InsertAsync(RecipeCategory category);
        Task DeleteAsync(int id);
        Task DeleteAsync(RecipeCategory category);
        Task UpdateAsync(RecipeCategory category);
    }
}
