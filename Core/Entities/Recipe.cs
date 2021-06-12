using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string PreparationTime { get; set; }
        public IEnumerable<RecipeIngredient> Ingredients { get; set; }
        public int ServingSize { get; set; }
        public IEnumerable<RecipeStep> RecipeSteps { get; set; }
        public string UrlName { get; set; }
        public RecipeCategory RecipeCategory { get; set; }
        public int RecipeCategoryId { get; set; }
        public Diet Diet { get; set; }
        public int DietId { get; set; }
        public Intake Intake { get; set; }
        public int IntakeId { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
