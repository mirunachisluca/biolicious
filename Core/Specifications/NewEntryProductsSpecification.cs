using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class NewEntryProductsSpecification : BaseSpecification<Product>
    {
        public NewEntryProductsSpecification() : base(x=>x.NewEntry.Equals(true))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductCategory);
            AddInclude(p => p.ProductSubcategory);
            AddOrderBy(p => p.Name);
        }
    }
}
