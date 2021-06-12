using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Weight { get; set; }
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
        public string UrlName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
