using Lab2.DAL.Models;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface IRepairingModelsRepository
    {
        Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges);
        Task<IEnumerable<RepairingModel>> Get(int rowsCount, string cacheKey);
        Task<RepairingModel> GetById(Guid id, bool trackChanges);
        Task Create(RepairingModel entity);
        Task Create(IEnumerable<RepairingModel> entities);
        Task Delete(RepairingModel entity);
        Task Update(RepairingModel entity);
    }
}
