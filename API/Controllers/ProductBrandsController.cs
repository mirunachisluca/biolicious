using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductBrandService _productBrandService;

        public ProductBrandsController(IProductBrandService productBrandService)
        {
            _productBrandService = productBrandService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrandDTO>>> GetProductBrands()
        {
            var brands = await _productBrandService.GetProductBrandsAsync();

            return Ok(brands);
        }
    }
}
