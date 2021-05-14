using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class RecipeCategoryService : IRecipeCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RecipeCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RecipeCategoryDTO> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.RecipeCategoryRepository.GetByIdAsync(id);

            return _mapper.Map<RecipeCategoryDTO>(category);
        }

        public async Task<IReadOnlyList<RecipeCategoryDTO>> GetRecipeCategoriesAsync()
        {
            var categories = await _unitOfWork.RecipeCategoryRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<RecipeCategoryDTO>>(categories);
        }

        public async Task InsertAsync(RecipeCategory category)
        {
            await _unitOfWork.RecipeCategoryRepository.InsertAsync(category);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(RecipeCategory category)
        {
            _unitOfWork.RecipeCategoryRepository.Update(category);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.RecipeCategoryRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(RecipeCategory category)
        {
            _unitOfWork.RecipeCategoryRepository.Delete(category);
            await _unitOfWork.Save();
        }
    }
}
