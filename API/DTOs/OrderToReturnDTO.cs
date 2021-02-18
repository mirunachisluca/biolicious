using Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class OrderToReturnDTO
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address ShippingAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public double DeliveryPrice { get; set; }
        public IEnumerable<OrderItemDTO> OrderItems { get; set; }
        public double SavedAmount { get; set; }
        public double Subtotal { get; set; }
        public double Total { get; set; }
        public string OrderStatus { get; set; }
    }
}
