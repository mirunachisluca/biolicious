using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart> GetShopingCartAsync(string id);
        Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCart shoppingCart);
        Task<bool> DeleteShoppingCartAsync(string id);
        Task<string> GetShoppingCartIdAsync(string userEmail);
        Task<object> SetShoppingCartIdAsync(string userEmail, string cartId);
    }
}
