using Lab2.DAL.Models;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface IFaultsRepository
    {
        Task<IEnumerable<Fault>> GetAll(bool trackChanges);
        Task<IEnumerable<Fault>> Get(int rowsCount, string cacheKey);
        Task<Fault> GetById(Guid id, bool trackChanges);
        Task Create(Fault entity);
        Task Create(IEnumerable<Fault> entities);
        Task Delete(Fault entity);
        Task Update(Fault entity);
    }
}
