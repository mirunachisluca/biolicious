using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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
        private readonly IWebHostEnvironment _hostEnvironment;

        public RecipesController(IRecipeService recipeService, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _recipeService = recipeService;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
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

        [HttpPost]
        public async Task<ActionResult<RecipeDTO>> Insert([FromForm] Recipe recipe)
        {
            recipe.PictureUrl = await SaveImage(recipe.ImageFile);

            await _recipeService.InsertAsync(recipe);

            var insertedRecipe = await _recipeService.GetByIdAsync(recipe.Id);

            var recipeToReturn = _mapper.Map<RecipeDTO>(insertedRecipe);

            return CreatedAtAction(nameof(GetRecipe), new { id = recipeToReturn.Id }, recipeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _recipeService.DeleteAsync(id);

            return NoContent();
        }

        [HttpDelete("steps/{id}")]
        public async Task<ActionResult> DeleteStep(int id)
        {
            await _recipeService.DeleteStepAsync(id);

            return NoContent();
        }

        [HttpDelete("ingredients/{id}")]
        public async Task<ActionResult> DeleteIngredient(int id)
        {
            await _recipeService.DeleteIngredientAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromForm] Recipe recipe)
        {
            recipe.PictureUrl = await SaveImage(recipe.ImageFile);

            await _recipeService.UpdateAsync(recipe);

            return NoContent();
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var pictureName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(15).ToArray()).Replace(" ", "-");

            var pictureUrl = "images/recipes/" + pictureName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);

            var picturePath = Path.Combine(_hostEnvironment.WebRootPath, pictureUrl);

            using (var fileStream = new FileStream(picturePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return pictureUrl;
        }
    }
}
