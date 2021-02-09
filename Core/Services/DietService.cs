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
    public class DietService : IDietService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DietService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DietDTO> GetByIdAsync(int id)
        {
            var diet = await _unitOfWork.DietRepository.GetByIdAsync(id);

            return _mapper.Map<DietDTO>(diet);
        }

        public async Task<IReadOnlyList<DietDTO>> GetDietsAsync()
        {
            var diets = await _unitOfWork.DietRepository.ListAllAsync();

            return _mapper.Map<IReadOnlyList<DietDTO>>(diets);
        }

        public Task InsertAsync(Diet diet)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Diet diet)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Diet diet)
        {
            throw new NotImplementedException();
        }
    }
}
