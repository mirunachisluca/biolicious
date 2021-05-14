using Core.Entities;

namespace Core.Specifications
{
    public class ProductBrandsWithSortFilterSpecification : BaseSpecification<ProductBrand>
    {
        public ProductBrandsWithSortFilterSpecification(string sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nameAsc":
                        AddOrderBy(b => b.Name);
                        break;
                    case "latest":
                        AddOrderByDesc(b => b.Id);
                        break;
                    default:
                        AddOrderBy(b => b.Name);
                        break;
                }
            }
        }
    }
}
