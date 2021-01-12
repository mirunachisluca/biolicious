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
                (string.IsNullOrEmpty(parameters.Search) || x.Name.ToLower().Contains(parameters.Search)) &&
                (!parameters.BrandId.HasValue || x.ProductBrandId == parameters.BrandId) &&
                (!parameters.TypeId.HasValue || x.ProductTypeId == parameters.TypeId))
        {
        }
    }
}
