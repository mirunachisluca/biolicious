using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class RecipeIngredient : BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}
