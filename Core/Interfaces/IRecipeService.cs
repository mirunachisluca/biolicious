using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDTO> GetByIdAsync(int id);
        Task<RecipeDTO> GetByUrlNameAsync(string urlName);
        Task<Pagination<RecipeDTO>> GetRecipesAsync(RecipeSpecificationParams parameters);
        Task InsertAsync(Recipe recipe);
        Task DeleteAsync(int id);
        Task DeleteAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
    }
}
