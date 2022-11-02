using Lab2.DAL.Interfaces.Repositories;
using Lab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Lab2.DAL.Repositories
{
    public class RepairingModelsRepository : RepositoryBase<RepairingModel>, IRepairingModelsRepository
    {
        private readonly IMemoryCache _memoryCache;

        public RepairingModelsRepository(ApplicationDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext)
        {
            _memoryCache = memoryCache;
        }

        public async Task Create(RepairingModel entity)
        {
            var n = await CreateEntity(entity);

            if (n > 0)
            {
                _memoryCache.Set(entity.Id, entity, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(CachingTime)
                });
            }
        }

        public async Task Create(IEnumerable<RepairingModel> entities) =>
            await CreateEntities(entities);

        public async Task Delete(RepairingModel entity)
        {
            var n = await DeleteEntity(entity);

            if (n > 0)
            {
                _memoryCache.Remove(entity.Id);
            }
        }

        public async Task<IEnumerable<RepairingModel>> Get(int rowsCount, string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<RepairingModel> entities))
            {
                entities = await dbContext.RepairingModels.Take(rowsCount).ToListAsync();
                if (entities != null)
                {
                    _memoryCache.Set(cacheKey, entities,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return entities;
        }

        public async Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<RepairingModel> GetById(Guid id, bool trackChanges)
        {
            if (!_memoryCache.TryGetValue(id, out RepairingModel entity))
            {
                entity = await GetByCondition(f => f.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

                if (entity != null)
                {
                    _memoryCache.Set(entity.Id, entity,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }

            return entity;
        }

        public async Task Update(RepairingModel entity) =>
            await UpdateEntity(entity);
    }
}
