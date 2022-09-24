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
    public class SparePartsRepository : RepositoryBase<SparePart>, ISparePartsRepository
    {
        public SparePartsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(SparePart entity) =>
            await CreateEntity(entity);

        public async Task Create(IEnumerable<SparePart> entities) =>
            await CreateEntities(entities);

        public async Task Delete(SparePart entity) =>
            await DeleteEntity(entity);

        public async Task<IEnumerable<SparePart>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<SparePart> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(f => f.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task Update(SparePart entity) =>
            await UpdateEntity(entity);
    }
}
