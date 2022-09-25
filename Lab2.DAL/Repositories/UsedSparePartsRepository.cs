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
    public class UsedSparePartsRepository : RepositoryBase<UsedSparePart>, IUsedSparePartsRepository
    {
        private readonly IMemoryCache _memoryCache;

        public UsedSparePartsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext) 
        {
            _memoryCache = memoryCache;
        }

        public async Task Create(UsedSparePart entity)
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

        public async Task Create(IEnumerable<UsedSparePart> entities) =>
            await CreateEntities(entities);

        public async Task Delete(UsedSparePart entity)
        {
            var n = await DeleteEntity(entity);

            if (n > 0)
            {
                _memoryCache.Remove(entity.Id);
            }
        }

        public async Task<IEnumerable<UsedSparePart>> Get(int rowsCount, string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<UsedSparePart> entities))
            {
                entities = await dbContext.UsedSpareParts.Take(rowsCount)
                    .Include(e => e.Fault).Include(e => e.SparePart).ToListAsync();
                if (entities != null)
                {
                    _memoryCache.Set(cacheKey, entities,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return entities;
        }

        public async Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).Include(usp => usp.Fault).Include(usp => usp.SparePart).ToListAsync();

        public async Task<UsedSparePart> GetById(Guid id, bool trackChanges)
        {
            if (!_memoryCache.TryGetValue(id, out UsedSparePart entity))
            {
                entity = await GetByCondition(sp => sp.Id.Equals(id), trackChanges)
                    .Include(sp => sp.Fault).Include(sp => sp.SparePart).SingleOrDefaultAsync();

                if (entity != null)
                {
                    _memoryCache.Set(entity.Id, entity,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }

            return entity;
        }

        public async Task Update(UsedSparePart entity) =>
            await UpdateEntity(entity);
    }
}
