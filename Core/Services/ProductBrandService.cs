using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ProductBrand brand)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ProductBrandDTO>> GetProductBrandsAsync()
        {
            var brands = await _unitOfWork.ProductBrandRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<ProductBrandDTO>>(brands);
        }

        public Task InsertAsync(ProductBrand brand)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductBrand brand)
        {
            throw new NotImplementedException();
        }
    }
}
