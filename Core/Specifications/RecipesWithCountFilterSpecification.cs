using Core.Entities;
using System;

namespace Core.Specifications
{
    public class RecipesWithCountFilterSpecification : BaseSpecification<Recipe>
    {
        public RecipesWithCountFilterSpecification(RecipeSpecificationParams parameters)
            : base(x =>
                 (String.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
                 (!(parameters.CategoryId.HasValue && parameters.CategoryId != 0) || x.RecipeCategoryId == parameters.CategoryId) &&
                 (!(parameters.DietId.HasValue && parameters.DietId != 0) || x.Diet.Id == parameters.DietId))
        {
        }
    }
}
