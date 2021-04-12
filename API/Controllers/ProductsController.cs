using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetProducts([FromQuery] ProductSpecificationParams parameters)
        {
            var products = await _productService.GetProductsAsync(parameters);

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetProduct))]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpGet("byName")]
        public async Task<ActionResult<ProductDTO>> GetProductByName([FromQuery] string urlName)
        {
            var product = await _productService.GetByUrlNameAsync(urlName);

            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }

        [HttpGet("newProducts")]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetNewProducts()
        {
            var products = await _productService.GetNewProductsAsync();

            return Ok(products);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProductDTO>> Insert(Product product)
        {
            await _productService.InsertAsync(product);

            var productToReturn = _mapper.Map<ProductDTO>(product);

            return CreatedAtAction(nameof(GetProduct), new { id = productToReturn.Id }, productToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update(Product product)
        {
            await _productService.UpdateAsync(product);

            return NoContent();
        }
    }
}
