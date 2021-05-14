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

        public int ProductBrandId { get; set; }
        public string ProductBrand { get; set; }

        public int ProductCategoryId { get; set; }
        public string ProductCategory { get; set; }

        public int ProductSubcategoryId { get; set; }
        public string ProductSubcategory { get; set; }

        public bool NewEntry { get; set; }

        public int Stock { get; set; }

        public string UrlName { get; set; }
    }
}
