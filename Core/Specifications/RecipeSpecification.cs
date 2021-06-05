using Core.Entities;
using System;

namespace Core.Specifications
{
    public class RecipeSpecification : BaseSpecification<Recipe>
    {
        public RecipeSpecification(RecipeSpecificationParams parameters)
            : base(x =>
                 (String.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
                 (!(parameters.CategoryId.HasValue && parameters.CategoryId != 0) || x.RecipeCategoryId == parameters.CategoryId) &&
                 (!(parameters.DietId.HasValue && parameters.DietId != 0) || x.Diet.Id == parameters.DietId))
        {
            AddInclude(r => r.Ingredients);
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductBrand)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductCategory)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductSubcategory)}");
            AddInclude(r => r.RecipeSteps);
            AddInclude(r => r.RecipeCategory);
            AddInclude(r => r.Diet);
            AddInclude(r => r.Intake);
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
            AddOrderBy(r => r.Name);
        }

        public RecipeSpecification(int id) : base(r => r.Id == id)
        {
            AddInclude(r => r.Ingredients);
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductBrand)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductCategory)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductSubcategory)}");
            AddInclude(r => r.RecipeSteps);
            AddInclude(r => r.RecipeCategory);
            AddInclude(r => r.Diet);
            AddInclude(r => r.Intake);
        }

        public RecipeSpecification(string url) : base(r => r.UrlName == url)
        {
            AddInclude(r => r.Ingredients);
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductBrand)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductCategory)}");
            AddInclude($"{nameof(Recipe.Ingredients)}.{nameof(RecipeIngredient.Product)}.{nameof(RecipeIngredient.Product.ProductSubcategory)}");
            AddInclude(r => r.RecipeSteps);
            AddInclude(r => r.RecipeCategory);
            AddInclude(r => r.Diet);
            AddInclude(r => r.Intake);
        }
    }
}
