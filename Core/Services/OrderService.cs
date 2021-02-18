using Core.Entities.Order;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderService(IUnitOfWork unitOfWork, IShoppingCartRepository shoppingCartRepository)
        {
            _unitOfWork = unitOfWork;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Order> GetByIdAsync(int orderId, string customerEmail)
        {
            var spec = new OrderWithItemsAndOrderFilterSpecification(orderId, customerEmail);

            return await _unitOfWork.OrderRepository.GetEntityWithSpec(spec);
        }

        public async Task<Order> CreateOrderAsync(string customerEmail, int deliveryMethodId, string shoppingCartId, Address shippingAddress)
        {
            var shoppingCart = await _shoppingCartRepository.GetShopingCartAsync(shoppingCartId);

            var items = new List<OrderItem>();

            foreach (var item in shoppingCart.Items)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.Id);

                var productItemOrdered = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);

                var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity, product.Discount);

                items.Add(orderItem);
            }

            var deliveryMethod = await _unitOfWork.DeliveryMethodRepository.GetByIdAsync(deliveryMethodId);

            var subtotal = items.Sum(i => (i.Price - (i.Price * i.Discount / 100)) * i.Quantity);

            var savedAmount = items.Sum(i => (i.Price * i.Discount / 100) * i.Quantity);

            var order = new Order(customerEmail, shippingAddress, deliveryMethod, items, savedAmount, subtotal);

            await _unitOfWork.OrderRepository.InsertAsync(order);
            var result = await _unitOfWork.Save();

            if (result <= 0) return null;

            await _shoppingCartRepository.DeleteShoppingCartAsync(shoppingCartId);

            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForCustomerAsync(string customerEmail)
        {
            var spec = new OrderWithItemsAndOrderFilterSpecification(customerEmail);

            var orders = await _unitOfWork.OrderRepository.ListAsync(spec);

            return orders;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.DeliveryMethodRepository.ListAllAsync();
        }
    }
}
