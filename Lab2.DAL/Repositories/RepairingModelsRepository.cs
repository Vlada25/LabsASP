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
    public class RepairingModelsRepository : RepositoryBase<RepairingModel>, IRepairingModelsRepository
    {
        public RepairingModelsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(RepairingModel entity) =>
            await CreateEntity(entity);

        public async Task Create(IEnumerable<RepairingModel> entities) =>
            await CreateEntities(entities);

        public async Task Delete(RepairingModel entity) =>
            await DeleteEntity(entity);

        public async Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<RepairingModel> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(f => f.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task Update(RepairingModel entity) =>
            await UpdateEntity(entity);
    }
}
