using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithFullInfoSpecification : BaseSpecification<Product>
    {
        public ProductsWithFullInfoSpecification(ProductSpecificationParams parameters)
            : base(x =>
                (string.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
                (!parameters.BrandId.HasValue || x.ProductBrandId == parameters.BrandId) &&
                (!parameters.CategoryId.HasValue || x.ProductCategoryId == parameters.CategoryId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductCategory);
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
        }
    }
}
