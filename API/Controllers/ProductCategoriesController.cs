using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        public readonly IProductCategoryService _productCategoryService;
        public readonly IMapper _mapper;

        public ProductCategoriesController(IProductCategoryService productCategoryService, IMapper mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductCategoryDTO>>> GetProductCategories([FromQuery] string sort)
        {
            var categories = await _productCategoryService.GetProductCategoriesAsync(sort);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetProductCategory))]
        public async Task<ActionResult<ProductCategoryDTO>> GetProductCategory(int id)
        {
            var category = await _productCategoryService.GetProductCategoryAsync(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<ProductCategoryDTO>> Insert(ProductCategory category)
        {
            await _productCategoryService.InsertAsync(category);

            var categoryToReturn = _mapper.Map<ProductCategoryDTO>(category);

            return CreatedAtAction(nameof(GetProductCategory), new { id = categoryToReturn.Id }, categoryToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productCategoryService.DeleteAsync(id);

            return NoContent();
        }

        [HttpDelete("subcategory/{id}")]
        public async Task<ActionResult> DeleteSubcategory(int id)
        {
            await _productCategoryService.DeleteSubcategoryAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductCategory category)
        {
            await _productCategoryService.UpdateAsync(category);

            return NoContent();
        }

        [HttpPut("subcategory")]
        public async Task<ActionResult> Update(ProductSubcategory subcategory)
        {
            await _productCategoryService.UpdateSubcategoryAsync(subcategory);

            return NoContent();
        }
    }
}
