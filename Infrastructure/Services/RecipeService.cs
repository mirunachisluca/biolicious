using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RecipeDTO> GetByIdAsync(int id)
        {
            var spec = new RecipeSpecification(id);

            var recipe = await _unitOfWork.RecipeRepository.GetEntityWithSpec(spec);

            return _mapper.Map<RecipeDTO>(recipe);
        }

        public async Task<RecipeDTO> GetByUrlNameAsync(string urlName)
        {
            var spec = new RecipeSpecification(urlName);

            var recipe = await _unitOfWork.RecipeRepository.GetEntityWithSpec(spec);

            return _mapper.Map<RecipeDTO>(recipe);
        }

        public async Task<Pagination<RecipeDTO>> GetRecipesAsync(RecipeSpecificationParams parameters)
        {
            var spec = new RecipeSpecification(parameters);

            var recipes = await _unitOfWork.RecipeRepository.ListAsync(spec);

            var countSpec = new RecipesWithCountFilterSpecification(parameters);

            var totalItems = await _unitOfWork.RecipeRepository.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<RecipeDTO>>(recipes);

            return new Pagination<RecipeDTO>(parameters.PageIndex, parameters.PageSize, totalItems, data);
        }

        public async Task InsertAsync(Recipe recipe)
        {
            recipe.UrlName = recipe.Name.ToLower().Replace(" ", "-");
            await _unitOfWork.RecipeRepository.InsertAsync(recipe);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.RecipeRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(Recipe recipe)
        {
            _unitOfWork.RecipeRepository.Delete(recipe);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            recipe.UrlName = recipe.Name.ToLower().Replace(" ", "-");
            _unitOfWork.RecipeRepository.Update(recipe);
            await _unitOfWork.Save();
        }

        public async Task DeleteIngredientAsync(int id)
        {
            await _unitOfWork.RecipeIngredientRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteStepAsync(int id)
        {
            await _unitOfWork.RecipeStepRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

    }
}
