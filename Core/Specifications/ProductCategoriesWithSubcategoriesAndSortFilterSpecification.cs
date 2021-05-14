using Core.Entities;

namespace Core.Specifications
{
    public class ProductCategoriesWithSubcategoriesAndSortFilterSpecification : BaseSpecification<ProductCategory>
    {
        public ProductCategoriesWithSubcategoriesAndSortFilterSpecification(string sort)
        {
            AddInclude(c => c.Subcategories);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nameAsc":
                        AddOrderBy(c => c.Name);
                        break;
                    case "latest":
                        AddOrderByDesc(c => c.Id);
                        break;
                    default:
                        AddOrderBy(c => c.Id);
                        break;
                }
            }
        }

        public ProductCategoriesWithSubcategoriesAndSortFilterSpecification(int id) : base(c => c.Id == id)
        {
            AddInclude(c => c.Subcategories);
        }
    }
}
