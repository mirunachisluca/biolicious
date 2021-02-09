using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductBrandService
    {
        Task<IReadOnlyList<ProductBrandDTO>> GetProductBrandsAsync();
        Task InsertAsync(ProductBrand brand);
        Task DeleteAsync(int id);
        Task DeleteAsync(ProductBrand brand);
        Task UpdateAsync(ProductBrand brand);
    }
}
