using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
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
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeService recipeService, IMapper mapper)
        {
            _recipeService = recipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<RecipeDTO>>> GetRecipes([FromQuery] RecipeSpecificationParams parameters)
        {
            var recipes = await _recipeService.GetRecipesAsync(parameters);

            return Ok(recipes);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetRecipe))]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);

            return Ok(recipe);
        }

        [HttpGet("byName")]
        public async Task<ActionResult<RecipeDTO>> GetRecipeByName([FromQuery] string urlName)
        {
            var recipe = await _recipeService.GetByUrlNameAsync(urlName);

            if (recipe == null)
                return NotFound();
            else
                return Ok(recipe);
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Insert(Recipe recipe)
        {
            await _recipeService.InsertAsync(recipe);

            var recipeToReturn = _mapper.Map<RecipeDTO>(recipe);

            return CreatedAtAction(nameof(GetRecipe), new { id = recipe.Id }, recipeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _recipeService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Update(Recipe recipe)
        {
            await _recipeService.UpdateAsync(recipe);

            return NoContent();
        }
    }
}
