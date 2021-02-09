using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public string PreparationTime { get; set; }
        public IEnumerable<RecipeIngredientDTO> Ingredients { get; set; }
        public int ServingSize { get; set; }
        public IEnumerable<string> RecipeSteps { get; set; }
        public string RecipeCategory { get; set; }
        public string Diet { get; set; }
    }
}
