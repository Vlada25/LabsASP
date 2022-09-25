using Lab2.DAL.Interfaces.Repositories;
using Lab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Repositories
{
    public class SparePartsRepository : RepositoryBase<SparePart>, ISparePartsRepository
    {
        private readonly IMemoryCache _memoryCache;

        public SparePartsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext) 
        {
            _memoryCache = memoryCache;
        }

        public async Task Create(SparePart entity)
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

        public async Task Create(IEnumerable<SparePart> entities) =>
            await CreateEntities(entities);

        public async Task Delete(SparePart entity)
        {
            var n = await DeleteEntity(entity);

            if (n > 0)
            {
                _memoryCache.Remove(entity.Id);
            }
        }

        public async Task<IEnumerable<SparePart>> Get(int rowsCount, string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<SparePart> entities))
            {
                entities = await dbContext.SpareParts.Take(rowsCount).ToListAsync();
                if (entities != null)
                {
                    _memoryCache.Set(cacheKey, entities,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return entities;
        }

        public async Task<IEnumerable<SparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<SparePart> GetById(Guid id, bool trackChanges)
        {
            if (!_memoryCache.TryGetValue(id, out SparePart entity))
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

        public async Task Update(SparePart entity) =>
            await UpdateEntity(entity);
    }
}
