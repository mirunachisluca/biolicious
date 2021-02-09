using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDietService
    {
        Task<DietDTO> GetByIdAsync(int id);
        Task<IReadOnlyList<DietDTO>> GetDietsAsync();
        Task InsertAsync(Diet diet);
        Task DeleteAsync(int id);
        Task DeleteAsync(Diet diet);
        Task UpdateAsync(Diet diet);
    }
}
