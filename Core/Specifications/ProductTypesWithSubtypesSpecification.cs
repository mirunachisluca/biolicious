using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductTypesWithSubtypesSpecification : BaseSpecification<ProductCategory>
    {
        public ProductTypesWithSubtypesSpecification()
        {
            AddInclude(t => t.Subcategories);
        }
    }
}
