using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class RecipeSpecification : BaseSpecification<Recipe>
    {
        public RecipeSpecification(RecipeSpecificationParams parameters)
            : base(x =>
                 (!parameters.CategoryId.HasValue || x.RecipeCategoryId == parameters.CategoryId) &&
                 (!parameters.DietId.HasValue || x.Diet.Id == parameters.DietId ))
        {
            AddInclude(r => r.Ingredients);
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}");
            AddInclude(r => r.RecipeSteps);
            AddInclude(r => r.RecipeCategory);
            AddInclude(r => r.Diet);
        }

        public RecipeSpecification(int id) : base(r => r.Id == id)
        {
            AddInclude(r => r.Ingredients);
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}");
            AddInclude(r => r.RecipeSteps);
            AddInclude(r => r.RecipeCategory);
            AddInclude(r => r.Diet);
        }
    }
}
