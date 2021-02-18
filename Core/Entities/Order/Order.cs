using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Order
{
    public class Order : BaseEntity
    {
        public Order()
        {
        }

        public Order(string customerEmail, Address shippingAddress, DeliveryMethod deliveryMethod, IEnumerable<OrderItem> orderItems, double savedAmount, double subtotal)
        {
            CustomerEmail = customerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            SavedAmount = savedAmount;
            Subtotal = subtotal;
        }

        public string CustomerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public Address ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public double SavedAmount { get; set; }
        public double Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }

        public double GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}
