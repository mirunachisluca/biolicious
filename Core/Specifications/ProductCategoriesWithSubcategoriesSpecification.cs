using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductCategoriesWithSubcategoriesSpecification : BaseSpecification<ProductCategory>
    {
        public ProductCategoriesWithSubcategoriesSpecification()
        {
            AddInclude(t => t.Subcategories);
        }
    }
}
