using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductSubcategory : BaseEntity
    {
        public string Name { get; set; }
        public ProductCategory ProductType { get; set; }
        public int ProductTypeId { get; set; }
    }
}
