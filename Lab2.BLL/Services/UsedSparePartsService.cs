using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.DAL.Interfaces;
using Lab2.DAL.Models;
using Lab2.DTO.UsedSparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BLL.Services
{
    public class UsedSparePartsService : IUsedSparePartsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UsedSparePartsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task Create(UsedSparePartForCreationDto entityForCreation)
        {
            var entities = _mapper.Map<UsedSparePart>(entityForCreation);

            await _repositoryManager.UsedSparePartsRepository.Create(entities);
        }

        public async Task Create(IEnumerable<UsedSparePart> entityForCreation) =>
            await _repositoryManager.UsedSparePartsRepository.Create(entityForCreation);

        public async Task Delete(Guid id)
        {
            var entity = await _repositoryManager.UsedSparePartsRepository.GetById(id, false);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            await _repositoryManager.UsedSparePartsRepository.Delete(entity);
        }

        public async Task<IEnumerable<UsedSparePartDto>> Get(int rowsCount, string cacheKey)
        {
            var usedSpareParts = await _repositoryManager.UsedSparePartsRepository.Get(rowsCount, cacheKey);

            return _mapper.Map<IEnumerable<UsedSparePartDto>>(usedSpareParts);
        }

        public async Task<IEnumerable<UsedSparePartDto>> GetAll()
        {
            var usedSpareParts = await _repositoryManager.UsedSparePartsRepository.GetAll(false);

            return _mapper.Map<IEnumerable<UsedSparePartDto>>(usedSpareParts);
        }

        public async Task<UsedSparePartDto> GetById(Guid id)
        {
            var usedSparePart = await _repositoryManager.UsedSparePartsRepository.GetById(id, false);

            return _mapper.Map<UsedSparePartDto>(usedSparePart);
        }

        public async Task Update(Guid id, UsedSparePartForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.UsedSparePartsRepository.GetById(id, true);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            _mapper.Map(entityForUpdate, entity);
            await _repositoryManager.UsedSparePartsRepository.Update(entity);
        }
    }
}
