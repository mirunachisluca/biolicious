using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Order
{
    public class DeliveryMethod : BaseEntity
    {
        public string Name { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
