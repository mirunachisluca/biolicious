using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Order
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, double price, int quantity, int discount)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
            Discount = discount;
        }

        public ProductItemOrdered ItemOrdered { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
    }
}
