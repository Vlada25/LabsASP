using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAllEntities(bool trackChanges);
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateEntity(T entity);
        Task CreateEntities(IEnumerable<T> entities);
        Task UpdateEntity(T entity);
        Task DeleteEntity(T entity);
    }
}
