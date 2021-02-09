using Core.DTOs;
using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDTO> GetByIdAsync(int id);
        Task<IReadOnlyList<RecipeDTO>> GetRecipesAsync(RecipeSpecificationParams parameters);
        Task InsertAsync(Recipe recipe);
        Task DeleteAsync(int id);
        Task DeleteAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
    }
}
