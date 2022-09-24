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
    public class FaultsRepository : RepositoryBase<Fault>, IFaultsRepository
    {
        public FaultsRepository(AppDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Fault entity) =>
            await CreateEntity(entity);

        public async Task Create(IEnumerable<Fault> entities) =>
            await CreateEntities(entities);

        public async Task Delete(Fault entity) =>
            await DeleteEntity(entity);

        public async Task<IEnumerable<Fault>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).Include(f => f.RepairingModel).ToListAsync();

        public async Task<Fault> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(f => f.Id.Equals(id), trackChanges).Include(f => f.RepairingModel).SingleOrDefaultAsync();

        public async Task Update(Fault entity) =>
            await UpdateEntity(entity);
    }
}
