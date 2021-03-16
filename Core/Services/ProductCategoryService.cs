using AutoMapper;
using Core.DTOs;
using Core.Interfaces;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductCategoryDTO>> GetProductCategoriesAsync()
        {
            var spec = new ProductCategoriesWithSubcategoriesSpecification();
            
            var categories = await _unitOfWork.ProductCategoryRepository.ListAsync(spec);

            return _mapper.Map<IReadOnlyList<ProductCategoryDTO>>(categories);
        }
    }
}
