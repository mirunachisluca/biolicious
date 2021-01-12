using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RecipeStep : BaseEntity
    {
        public string Step { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}
