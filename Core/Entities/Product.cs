using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Desciption { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string PictureUrl { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductSubcategory ProductSubcategory { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public bool NewEntry { get; set; }
        public int Stock { get; set; }
    }
}
