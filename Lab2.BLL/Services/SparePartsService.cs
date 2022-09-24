using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.DAL.Interfaces;
using Lab2.DAL.Models;
using Lab2.DTO.SparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BLL.Services
{
    public class SparePartsService : ISparePartsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SparePartsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task Create(SparePartForCreationDto entityForCreation)
        {
            var entities = _mapper.Map<SparePart>(entityForCreation);

            await _repositoryManager.SparePartsRepository.Create(entities);
        }

        public async Task Create(IEnumerable<SparePart> entityForCreation) =>
            await _repositoryManager.SparePartsRepository.Create(entityForCreation);

        public async Task Delete(Guid id)
        {
            var entity = await _repositoryManager.SparePartsRepository.GetById(id, false);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            await _repositoryManager.SparePartsRepository.Delete(entity);
        }

        public async Task<IEnumerable<SparePartDto>> GetAll()
        {
            var spareParts = await _repositoryManager.SparePartsRepository.GetAll(false);

            return _mapper.Map<IEnumerable<SparePartDto>>(spareParts);
        }

        public async Task<SparePartDto> GetById(Guid id)
        {
            var sparePart = await _repositoryManager.SparePartsRepository.GetById(id, false);

            return _mapper.Map<SparePartDto>(sparePart);
        }

        public async Task Update(Guid id, SparePartForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.SparePartsRepository.GetById(id, true);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            _mapper.Map(entityForUpdate, entity);
            await _repositoryManager.SparePartsRepository.Update(entity);
        }
    }
}
