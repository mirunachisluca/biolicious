using Core.Entities;
using System;

namespace Core.Specifications
{
    public class ProductsWithFullInfoSpecification : BaseSpecification<Product>
    {
        public ProductsWithFullInfoSpecification(ProductSpecificationParams parameters)
            : base(x =>
                (String.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
                (!(parameters.BrandId.HasValue && parameters.BrandId != 0) || x.ProductBrandId == parameters.BrandId) &&
                (!parameters.CategoryId.HasValue || x.ProductCategoryId == parameters.CategoryId) &&
                (!(parameters.SubcategoryId.HasValue && parameters.SubcategoryId != 0) || x.ProductSubcategoryId == parameters.SubcategoryId))
        {

            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductSubcategory);
            AddOrderBy(p => p.Name);
            ApplyPaging(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);

            if (!string.IsNullOrEmpty(parameters.Sort))
            {
                switch (parameters.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

        }

        public ProductsWithFullInfoSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductSubcategory);
        }

        public ProductsWithFullInfoSpecification(string url) : base(p => p.UrlName == url)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductSubcategory);
        }
    }
}
