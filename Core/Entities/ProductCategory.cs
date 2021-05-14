using System.Collections.Generic;

namespace Core.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<ProductSubcategory> Subcategories { get; set; }
    }
}
