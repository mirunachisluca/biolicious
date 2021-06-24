using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
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

        public async Task<ProductCategoryDTO> GetProductCategoryAsync(int id)
        {
            var spec = new ProductCategoriesWithSubcategoriesAndSortFilterSpecification(id);

            var category = await _unitOfWork.ProductCategoryRepository.GetEntityWithSpec(spec);

            return _mapper.Map<ProductCategoryDTO>(category);
        }

        public async Task<IReadOnlyList<ProductCategoryDTO>> GetProductCategoriesAsync(string sort)
        {
            var spec = new ProductCategoriesWithSubcategoriesAndSortFilterSpecification(sort);

            var categories = await _unitOfWork.ProductCategoryRepository.ListAsync(spec);

            return _mapper.Map<IReadOnlyList<ProductCategoryDTO>>(categories);
        }

        public async Task InsertAsync(ProductCategory category)
        {
            await _unitOfWork.ProductCategoryRepository.InsertAsync(category);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(ProductCategory category)
        {
            _unitOfWork.ProductCategoryRepository.Update(category);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ProductCategoryRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(ProductCategory category)
        {
            _unitOfWork.ProductCategoryRepository.Delete(category);
            await _unitOfWork.Save();
        }

        public async Task DeleteSubcategoryAsync(int id)
        {
            await _unitOfWork.ProductSubcategoryRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task UpdateSubcategoryAsync(ProductSubcategory subcategory)
        {
            _unitOfWork.ProductSubcategoryRepository.Update(subcategory);
            await _unitOfWork.Save();
        }
    }
}
