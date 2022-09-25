using Lab2.DAL.Models;
using Lab2.DTO.Fault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BLL.Interfaces.Services
{
    public interface IFaultsService
    {
        Task<IEnumerable<FaultDto>> GetAll();
        Task<IEnumerable<FaultDto>> Get(int rowsCount, string cacheKey);
        Task<FaultDto> GetById(Guid id);
        Task Create(FaultForCreationDto entityForCreation);
        Task Create(IEnumerable<Fault> entityForCreation);
        Task Delete(Guid id);
        Task Update(Guid id, FaultForUpdateDto entityForUpdate);
    }
}
