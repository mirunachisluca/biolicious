using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithCountFilterSpecification : BaseSpecification<Product>
    {
        public ProductsWithCountFilterSpecification(ProductSpecificationParams parameters)
            : base(x =>
                (String.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
                (!(parameters.BrandId.HasValue && parameters.BrandId != 0) || x.ProductBrandId == parameters.BrandId) &&
                (!parameters.CategoryId.HasValue || x.ProductCategoryId == parameters.CategoryId) &&
                (!(parameters.SubcategoryId.HasValue && parameters.SubcategoryId != 0) || x.ProductSubcategoryId == parameters.SubcategoryId))
        {
        }
    }
}
