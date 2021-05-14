using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
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

        public async Task InsertAsync(Diet diet)
        {
            await _unitOfWork.DietRepository.InsertAsync(diet);
            await _unitOfWork.Save();
        }

        public async Task UpdateAsync(Diet diet)
        {
            _unitOfWork.DietRepository.Update(diet);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.DietRepository.DeleteAsync(id);
            await _unitOfWork.Save();
        }

        public async Task DeleteAsync(Diet diet)
        {
            _unitOfWork.DietRepository.Delete(diet);
            await _unitOfWork.Save();
        }
    }
}
