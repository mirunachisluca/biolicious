using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IReadOnlyList<RecipeCategoryDTO>> GetRecipeCategoriesAsync()
        {
            var categories = await _unitOfWork.RecipeCategoryRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<RecipeCategoryDTO>>(categories);
        }
    }
}
