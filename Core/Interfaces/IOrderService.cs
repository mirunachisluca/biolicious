using Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string customerEmail, int deliveryMethodId, string shoppingCartId, Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForCustomerAsync(string customerEmail);
        Task<Order> GetByIdAsync(int orderId, string customerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();

    }
}
