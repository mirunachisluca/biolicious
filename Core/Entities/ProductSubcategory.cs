namespace Core.Entities
{
    public class ProductSubcategory : BaseEntity
    {
        public string Name { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
