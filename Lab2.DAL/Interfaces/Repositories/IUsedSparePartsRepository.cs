using Lab2.DAL.Models;

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
