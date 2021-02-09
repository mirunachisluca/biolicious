using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RecipeIngredientDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        //public int ProductId { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
    }
}
