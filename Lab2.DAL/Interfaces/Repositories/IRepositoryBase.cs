using System.Linq.Expressions;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllEntities(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task<int> CreateEntity(T entity);
        Task CreateEntities(IEnumerable<T> entities);
        Task UpdateEntity(T entity);
        Task<int> DeleteEntity(T entity);
    }
}
