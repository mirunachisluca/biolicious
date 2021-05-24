using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductService _productService;

        public ShoppingCartController(IShoppingCartRepository cartRepository, IProductService productService)
        {
            _cartRepository = cartRepository;
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCartById(string id)
        {
            var cart = await _cartRepository.GetShopingCartAsync(id);

            if (cart != null)
            {
                var modified = false;

                foreach (var item in cart.Items)
                {
                    var product = await _productService.GetByIdAsync(item.Id);

                    if (CheckForUpdates(item, product))
                    {
                        item.Name = product.Name;
                        item.Price = product.Price;
                        item.Discount = product.Discount;
                        item.PictureUrl = product.PictureUrl;
                        item.Weight = product.Weight;
                        item.Brand = product.ProductBrand;
                        item.Category = product.ProductCategory;
                        item.Subcategory = product.ProductSubcategory;

                        modified = true;
                    }
                }

                if (modified)
                {
                    await UpdateShoppingCart(cart);
                }

                return Ok(cart);
            }

            return Ok(new ShoppingCart(id));
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

        private bool CheckForUpdates(ShoppingCartItem item, ProductDTO product)
        {
            if (item.Price != product.Price ||
                item.Discount != product.Discount ||
                !item.Weight.Equals(product.Weight) ||
                !item.PictureUrl.Equals(product.PictureUrl) ||
                !item.Name.Equals(product.Name) ||
                !item.Category.Equals(product.ProductCategory) ||
                !item.Brand.Equals(product.ProductBrand) ||
                item.Subcategory != product.ProductSubcategory)
            {
                return true;
            }

            return false;
        }
    }
}
