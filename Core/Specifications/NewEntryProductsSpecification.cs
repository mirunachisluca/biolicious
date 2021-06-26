using Core.Entities;

namespace Core.Specifications
{
    public class NewEntryProductsSpecification : BaseSpecification<Product>
    {
        public NewEntryProductsSpecification() : base(x => x.NewEntry.Equals(true))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductSubcategory);
            AddOrderBy(p => p.Name);
            AddOrderByDesc(p => p.Id);
            ApplyPaging(0, 10);
        }
    }
}
