using Lab2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL.Interfaces.Repositories
{
    public interface IRepairingModelsRepository
    {
        Task<IEnumerable<RepairingModel>> GetAll(bool trackChanges);
        Task<RepairingModel> GetById(Guid id, bool trackChanges);
        Task Create(RepairingModel entity);
        Task Create(IEnumerable<RepairingModel> entities);
        Task Delete(RepairingModel entity);
        Task Update(RepairingModel entity);
    }
}
