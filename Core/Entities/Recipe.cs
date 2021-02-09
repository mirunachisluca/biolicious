using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public RecipeCategory RecipeCategory { get; set; }
        public int RecipeCategoryId { get; set; }
        public Diet Diet { get; set; }
        public int DietId { get; set; }

    }
}
