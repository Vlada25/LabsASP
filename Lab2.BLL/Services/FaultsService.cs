using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.DAL.Interfaces;
using Lab2.DAL.Models;
using Lab2.DTO.Fault;

namespace Lab2.BLL.Services
{
    public class FaultsService : IFaultsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public FaultsService(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }


        public async Task Create(FaultForCreationDto entityForCreation)
        {
            var entities = _mapper.Map<Fault>(entityForCreation);

            await _repositoryManager.FaultsRepository.Create(entities);
        }

        public async Task Create(IEnumerable<Fault> entityForCreation) =>
            await _repositoryManager.FaultsRepository.Create(entityForCreation);

        public async Task Delete(Guid id)
        {
            var entity = await _repositoryManager.FaultsRepository.GetById(id, false);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            await _repositoryManager.FaultsRepository.Delete(entity);
        }

        public async Task<IEnumerable<FaultDto>> Get(int rowsCount, string cacheKey)
        {
            var faults = await _repositoryManager.FaultsRepository.Get(rowsCount, cacheKey);

            return _mapper.Map<IEnumerable<FaultDto>>(faults);
        }

        public async Task<IEnumerable<FaultDto>> GetAll()
        {
            var faults = await _repositoryManager.FaultsRepository.GetAll(false);

            return _mapper.Map<IEnumerable<FaultDto>>(faults);
        }

        public async Task<FaultDto> GetById(Guid id)
        {
            var fault = await _repositoryManager.FaultsRepository.GetById(id, false);

            return _mapper.Map<FaultDto>(fault);
        }

        public async Task Update(Guid id, FaultForUpdateDto entityForUpdate)
        {
            var entity = await _repositoryManager.FaultsRepository.GetById(id, true);

            if (entity == null)
            {
                throw new Exception($"Entity with id {id} doesn't exist in database!");
            }

            _mapper.Map(entityForUpdate, entity);
            await _repositoryManager.FaultsRepository.Update(entity);
        }
    }
}
