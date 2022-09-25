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
    public class FaultsRepository : RepositoryBase<Fault>, IFaultsRepository
    {
        private readonly IMemoryCache _memoryCache; 

        public FaultsRepository(AppDbContext dbContext, IMemoryCache memoryCache)
            : base(dbContext) 
        {
            _memoryCache = memoryCache;
        }

        public async Task Create(Fault entity)
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
            

        public async Task Create(IEnumerable<Fault> entities) =>
            await CreateEntities(entities);

        public async Task Delete(Fault entity)
        {
            var n = await DeleteEntity(entity);

            if (n > 0)
            {
                _memoryCache.Remove(entity.Id);
            }
        }

        public async Task<IEnumerable<Fault>> Get(int rowsCount, string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Fault> entities))
            {
                entities = await dbContext.Faults.Take(rowsCount).Include(e => e.RepairingModel).ToListAsync();
                if (entities != null)
                {
                    _memoryCache.Set(cacheKey, entities,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }
            return entities;
        }

        public async Task<IEnumerable<Fault>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).Include(f => f.RepairingModel).ToListAsync();

        public async Task<Fault> GetById(Guid id, bool trackChanges)
        {
            if (!_memoryCache.TryGetValue(id, out Fault entity))
            {
                entity = await GetByCondition(f => f.Id.Equals(id), trackChanges)
                    .Include(f => f.RepairingModel).SingleOrDefaultAsync();

                if (entity != null)
                {
                    _memoryCache.Set(entity.Id, entity,
                        new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(CachingTime)));
                }
            }

            return entity;
        }
            

        public async Task Update(Fault entity) =>
            await UpdateEntity(entity);
    }
}
