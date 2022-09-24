using Lab2.DAL.Models;
using Lab2.DTO.RepairingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BLL.Interfaces.Services
{
    public interface IRepairingModelsService
    {
        Task<IEnumerable<RepairingModelDto>> GetAll();
        Task<RepairingModelDto> GetById(Guid id);
        Task Create(RepairingModelForCreationDto entityForCreation);
        Task Create(IEnumerable<RepairingModel> entityForCreation);
        Task Delete(Guid id);
        Task Update(Guid id, RepairingModelForUpdateDto entityForUpdate);
    }
}
