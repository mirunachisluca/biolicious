using AutoMapper;
using Core.Interfaces;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Core.Helpers;

namespace Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var spec = new ProductsWithFullInfoSpecification(id);

            var product = await _unitOfWork.ProductRepository.GetEntityWithSpec(spec);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<Pagination<ProductDTO>> GetProductsAsync(ProductSpecificationParams parameters)
        {
            var spec = new ProductsWithFullInfoSpecification(parameters);

            var products = await _unitOfWork.ProductRepository.ListAsync(spec);

            var countSpec = new ProductsWithCountFilterSpecification(parameters);

            var totalItems = await _unitOfWork.ProductRepository.CountAsync(countSpec);

            var data = _mapper.Map<IReadOnlyList<ProductDTO>>(products);

            return new Pagination<ProductDTO>(parameters.PageIndex, parameters.PageSize, totalItems, data);
        }

        public async Task InsertAsync(Product product)
        {
            await _unitOfWork.ProductRepository.InsertAsync(product);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(Product product)
        {
            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
        }

    }
}
