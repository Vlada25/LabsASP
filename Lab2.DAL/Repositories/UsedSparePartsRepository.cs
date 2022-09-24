using Lab2.DAL.Interfaces.Repositories;
using Lab2.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Repositories
{
    public class UsedSparePartsRepository : RepositoryBase<UsedSparePart>, IUsedSparePartsRepository
    {
        public UsedSparePartsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(UsedSparePart entity) =>
            await CreateEntity(entity);

        public async Task Create(IEnumerable<UsedSparePart> entities) =>
            await CreateEntities(entities);

        public async Task Delete(UsedSparePart entity) =>
            await DeleteEntity(entity);

        public async Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).Include(usp => usp.Fault).Include(usp => usp.SparePart).ToListAsync();

        public async Task<UsedSparePart> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(f => f.Id.Equals(id), trackChanges).Include(usp => usp.Fault).Include(usp => usp.SparePart).SingleOrDefaultAsync();

        public async Task Update(UsedSparePart entity) =>
            await UpdateEntity(entity);
    }
}
