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
    public class DietsController : ControllerBase
    {
        private readonly IDietService _dietService;

        public DietsController(IDietService dietService)
        {
            _dietService = dietService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DietDTO>>> GetDiets()
        {
            var diets = await _dietService.GetDietsAsync();

            return Ok(diets);
        }
    }
}
