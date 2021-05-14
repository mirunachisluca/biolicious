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
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly IRecipeCategoryService _recipeCategoryService;
        private readonly IMapper _mapper;

        public RecipeCategoriesController(IRecipeCategoryService recipeCategoryService, IMapper mapper)
        {
            _recipeCategoryService = recipeCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RecipeCategoryDTO>>> GetRecipeCategories()
        {
            var categories = await _recipeCategoryService.GetRecipeCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetRecipeCategory))]
        public async Task<ActionResult<RecipeCategoryDTO>> GetRecipeCategory(int id)
        {
            var category = await _recipeCategoryService.GetByIdAsync(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(RecipeCategory category)
        {
            await _recipeCategoryService.InsertAsync(category);

            var categoryToReturn = _mapper.Map<RecipeCategoryDTO>(category);

            return CreatedAtAction(nameof(GetRecipeCategory), new { id = categoryToReturn.Id }, categoryToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> Update(RecipeCategory category)
        {
            await _recipeCategoryService.UpdateAsync(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _recipeCategoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
