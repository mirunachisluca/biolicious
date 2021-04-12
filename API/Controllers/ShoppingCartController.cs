using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _cartRepository;

        public ShoppingCartController(IShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartById(string id)
        {
            var cart = await _cartRepository.GetShopingCartAsync(id);

            return Ok(cart ?? new ShoppingCart(id));
        }

        [HttpGet("cartId")]
        public async Task<ActionResult<string>> GetCartIdByUserEmail(string userEmail)
        {
            var cartId = await _cartRepository.GetShoppingCartIdAsync(userEmail);

            return Ok(cartId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppingCart(ShoppingCart cart)
        {
            var updatedCart = await _cartRepository.UpdateShoppingCartAsync(cart);

            return Ok(updatedCart);
        }

        [HttpPost("updateCartId")]
        public async Task<ActionResult<object>> UpdateShoppingCartIdForUser(string userEmail, string cartId)
        {
            var updatedId = await _cartRepository.SetShoppingCartIdAsync(userEmail, cartId);

            return Ok(updatedId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShoppingCart(string id)
        {
            await _cartRepository.DeleteShoppingCartAsync(id);

            return NoContent();
        }
    }
}
