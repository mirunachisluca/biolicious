using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.DAL
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IDatabase _database;

        public ShoppingCartRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<ShoppingCart> GetShopingCartAsync(string id)
        {
            var cart = await _database.StringGetAsync(id);

            return cart.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(cart);
        }
         
        public async Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart shoppingCart)
        {
            var created = await _database.StringSetAsync(shoppingCart.Id, JsonSerializer.Serialize(shoppingCart), TimeSpan.FromDays(30));

            if (!created) return null;

            return await GetShopingCartAsync(shoppingCart.Id);
        }

        public async Task<bool> DeleteShoppingCartAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<string> GetShoppingCartIdAsync(string userEmail)
        {
            var cartId = await _database.StringGetAsync(userEmail);

            return cartId;
        }

        public async Task<object> SetShoppingCartIdAsync(string userEmail, string cartId)
        {
            var created = await _database.StringSetAsync(userEmail, cartId);

            if (!created) return null;

            return new { userEmail, cartId };
        }
    }
}
