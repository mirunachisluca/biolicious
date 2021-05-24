using Core.Entities;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;

        public PaymentService(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _unitOfWork = unitOfWork;
            _config = configuration;
        }

        public async Task<ShoppingCart> CreateOrUpdatePaymentIntent(string cartId)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            var cart = await _shoppingCartRepository.GetShopingCartAsync(cartId);

            var shippingPrice = 0d;

            if (cart.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.DeliveryMethodRepository.GetByIdAsync((int)cart.DeliveryMethodId);

                shippingPrice = deliveryMethod.Price;
            }

            var service = new PaymentIntentService();

            PaymentIntent intent;

            if (string.IsNullOrEmpty(cart.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)cart.Items.Sum(i => (i.Price - (i.Price * i.Discount / 100)) * 100 * i.Quantity) + (long)shippingPrice * 100,
                    Currency = "eur",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);

                cart.PaymentIntentId = intent.Id;
                cart.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)cart.Items.Sum(i => (i.Price - (i.Price * i.Discount / 100)) * 100 * i.Quantity) + (long)shippingPrice * 100
                };

                await service.UpdateAsync(cart.PaymentIntentId, options);
            }

            await _shoppingCartRepository.UpdateShoppingCartAsync(cart);

            return cart;
        }
    }
}

