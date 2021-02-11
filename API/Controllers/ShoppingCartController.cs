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
        public async Task<ActionResult<ShoppingCart>> GetBasketById(string id)
        {
            var cart = await _cartRepository.GetShopingCartAsync(id);

            return Ok(cart ?? new ShoppingCart(id));
        }

        [HttpPost("update")]
        public async Task<ActionResult<ShoppingCart>> UpdateShoppingCart(ShoppingCart cart)
        {
            var updatedCart = await _cartRepository.UpdateShoppingCartAsync(cart);

            return Ok(updatedCart);
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult> DeleteShoppingCart(string id)
        {
            await _cartRepository.DeleteShoppingCartAsync(id);

            return NoContent();
        }
    }
}
