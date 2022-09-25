using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.DAL.Interfaces;
using Lab2.DAL.Models;
using Lab2.DTO.RepairingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BLL.Services
{
    public class RepairingModelsService : IRepairingModelsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public RepairingModelsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task Create(RepairingModelForCreationDto entityForCreation)
        {
            var entities = _mapper.Map<RepairingModel>(entityForCreation);

            await _repositoryManager.RepairingModelsRepository.Create(entities);
        }

        public async Task Create(IEnumerable<RepairingModel> entityForCreation) =>
            await _repositoryManager.RepairingModelsRepository.Create(entityForCreation);

        public async Task Delete(Guid id)
        {
            var entity = await _repositoryManager.RepairingModelsRepository.GetById(id, false);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            await _repositoryManager.RepairingModelsRepository.Delete(entity);
        }

        public async Task<IEnumerable<RepairingModelDto>> Get(int rowsCount, string cacheKey)
        {
            var repairingModels = await _repositoryManager.RepairingModelsRepository.Get(rowsCount, cacheKey);

            return _mapper.Map<IEnumerable<RepairingModelDto>>(repairingModels);
        }

        public async Task<IEnumerable<RepairingModelDto>> GetAll()
        {
            var repairingModels = await _repositoryManager.RepairingModelsRepository.GetAll(false);

            return _mapper.Map<IEnumerable<RepairingModelDto>>(repairingModels);
        }

        public async Task<RepairingModelDto> GetById(Guid id)
        {
            var repairingModel = await _repositoryManager.RepairingModelsRepository.GetById(id, false);

            return _mapper.Map<RepairingModelDto>(repairingModel);
        }

        public async Task Update(Guid id, RepairingModelForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.RepairingModelsRepository.GetById(id, true);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            _mapper.Map(entityForUpdate, entity);
            await _repositoryManager.RepairingModelsRepository.Update(entity);
        }
    }
}
