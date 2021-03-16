using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Weight { get; set; }
        public int Discount { get; set; }
        public string PictureUrl { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSubcategory { get; set; }
        public bool NewEntry { get; set; }
        public int Stock { get; set; }
        public string UrlName { get; set; }
    }
}
