using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductBrandService _productBrandService;
        private readonly IMapper _mapper;

        public ProductBrandsController(IProductBrandService productBrandService, IMapper mapper)
        {
            _productBrandService = productBrandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductBrandDTO>>> GetProductBrands([FromQuery] string sort)
        {
            var brands = await _productBrandService.GetProductBrandsAsync(sort);

            return Ok(brands);
        }

        [HttpGet("id")]
        [ActionName(nameof(GetProductBrand))]
        public async Task<ActionResult<ProductBrandDTO>> GetProductBrand(int id)
        {
            var brand = await _productBrandService.GetProductBrandAsync(id);

            if (brand == null) return NotFound();

            return Ok(brand);
        }

        [HttpGet("category")]
        public async Task<ActionResult<IReadOnlyList<ProductBrandDTO>>> GetProductBrandsForCategory([FromQuery] int categoryId, int subcategoryId)
        {
            var brands = await _productBrandService.GetProductBrandsForCategoryAsync(categoryId, subcategoryId);

            return Ok(brands);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Insert(ProductBrand brand)
        {
            await _productBrandService.InsertAsync(brand);

            var brandToReturn = _mapper.Map<ProductBrandDTO>(brand);

            return CreatedAtAction(nameof(GetProductBrand), new { id = brandToReturn.Id }, brandToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productBrandService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductBrand brand)
        {
            await _productBrandService.UpdateAsync(brand);

            return NoContent();
        }
    }
}
