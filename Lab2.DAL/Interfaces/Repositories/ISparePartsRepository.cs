using Lab2.DAL.Models;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface ISparePartsRepository
    {
        Task<IEnumerable<SparePart>> GetAll(bool trackChanges);
        Task<IEnumerable<SparePart>> Get(int rowsCount, string cacheKey);
        Task<SparePart> GetById(Guid id, bool trackChanges);
        Task Create(SparePart entity);
        Task Create(IEnumerable<SparePart> entities);
        Task Delete(SparePart entity);
        Task Update(SparePart entity);
    }
}
