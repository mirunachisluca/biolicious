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
    public class DietsController : ControllerBase
    {
        private readonly IDietService _dietService;
        private readonly IMapper _mapper;

        public DietsController(IDietService dietService, IMapper mapper)
        {
            _dietService = dietService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DietDTO>>> GetDiets()
        {
            var diets = await _dietService.GetDietsAsync();

            return Ok(diets);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetDiet))]
        public async Task<ActionResult<DietDTO>> GetDiet(int id)
        {
            var diet = await _dietService.GetByIdAsync(id);

            if (diet == null) return NotFound();

            return Ok(diet);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Diet diet)
        {
            await _dietService.InsertAsync(diet);

            var dietToReturn = _mapper.Map<DietDTO>(diet);

            return CreatedAtAction(nameof(GetDiet), new { id = dietToReturn.Id }, dietToReturn);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Diet diet)
        {
            await _dietService.UpdateAsync(diet);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _dietService.DeleteAsync(id);

            return NoContent();
        }
    }
}
