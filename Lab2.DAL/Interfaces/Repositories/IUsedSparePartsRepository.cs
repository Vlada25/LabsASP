using Lab2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface IUsedSparePartsRepository
    {
        Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges);
        Task<IEnumerable<UsedSparePart>> Get(int rowsCount, string cacheKey);
        Task<UsedSparePart> GetById(Guid id, bool trackChanges);
        Task Create(UsedSparePart entity);
        Task Create(IEnumerable<UsedSparePart> entities);
        Task Delete(UsedSparePart entity);
        Task Update(UsedSparePart entity);
    }
}
