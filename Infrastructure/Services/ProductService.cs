using AutoMapper;
using Core.Interfaces;
using Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Core.Helpers;

namespace Infrastructure.Services
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

        public async Task<ProductDTO> GetByUrlNameAsync(string urlName)
        {
            var spec = new ProductsWithFullInfoSpecification(urlName);

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

        public async Task<IReadOnlyList<ProductDTO>> GetNewProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.ListAsync(new NewEntryProductsSpecification());

            return _mapper.Map<IReadOnlyList<ProductDTO>>(products);
        }

        public async Task InsertAsync(Product product)
        {
            product.UrlName = await GetProductUrlName(product.ProductBrandId, product.Name, product.Weight);
            if (product.ProductSubcategoryId == 0) product.ProductSubcategoryId = null;

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
            product.UrlName = await GetProductUrlName(product.ProductBrandId, product.Name, product.Weight);
            if (product.ProductSubcategoryId == 0) product.ProductSubcategoryId = null;

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.Save();
        }

        private async Task<string> GetProductUrlName(int brandId, string name, string weight)
        {
            var brand = await _unitOfWork.ProductBrandRepository.GetByIdAsync(brandId);

            var brandName = brand.Name.ToLower().Replace(" ", "-").Replace(".", "");
            var productName = name.ToLower().Replace(" ", "-");
            weight = weight.ToLower().Replace(" ", "-");

            return brandName + "-" + productName + "-" + weight;
        }

    }
}
