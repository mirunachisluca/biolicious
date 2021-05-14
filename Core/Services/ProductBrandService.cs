using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductBrandService : IProductBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductBrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductBrandDTO> GetProductBrandAsync(int id)
        {
            var brand = await _unitOfWork.ProductBrandRepository.GetByIdAsync(id);

            return _mapper.Map<ProductBrandDTO>(brand);
        }


        public async Task<IReadOnlyList<ProductBrandDTO>> GetProductBrandsAsync(string sort)
        {
            var spec = new ProductBrandsWithSortFilterSpecification(sort);

            var brands = await _unitOfWork.ProductBrandRepository.ListAsync(spec);

            //brands = brands.OrderByDescending(b => b.Id).ToList();

            return _mapper.Map<IReadOnlyList<ProductBrandDTO>>(brands);
        }

        public async Task InsertAsync(ProductBrand brand)
        {
            await _unitOfWork.ProductBrandRepository.InsertAsync(brand);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(ProductBrand brand)
        {
            _unitOfWork.ProductBrandRepository.Update(brand);
            await _unitOfWork.Save();
        }
        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ProductBrandRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(ProductBrand brand)
        {
            _unitOfWork.ProductBrandRepository.Delete(brand);
            await _unitOfWork.Save();
        }

        public async Task<IReadOnlyList<ProductBrandDTO>> GetProductBrandsForCategoryAsync(int categoryId, int subcategoryId)
        {
            var products = await _unitOfWork.ProductRepository.ListAllAsync();
            var brands = await _unitOfWork.ProductBrandRepository.ListAllAsync();

            if (subcategoryId != 0)
            {
                var specifiedBrands = (from brand in brands
                                       join product in products on brand equals product.ProductBrand
                                       where product.ProductCategoryId == categoryId && product.ProductSubcategoryId == subcategoryId
                                       select brand).Distinct();

                return _mapper.Map<IReadOnlyList<ProductBrandDTO>>(specifiedBrands);
            }
            else
            {
                var specifiedBrands = (from brand in brands
                                       join product in products on brand equals product.ProductBrand
                                       where product.ProductCategoryId == categoryId
                                       select brand).Distinct();

                return _mapper.Map<IReadOnlyList<ProductBrandDTO>>(specifiedBrands);
            }
        }
    }
}
