using Core.DTOs;
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
    public class RecipeCategoriesController : ControllerBase
    {
        private readonly IRecipeCategoryService _recipeCategoryService;

        public RecipeCategoriesController(IRecipeCategoryService recipeCategoryService)
        {
            _recipeCategoryService = recipeCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<RecipeCategoryDTO>>> GetRecipeCategories()
        {
            var categories = await _recipeCategoryService.GetRecipeCategoriesAsync();

            return Ok(categories);
        }
    }
}
