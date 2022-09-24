using Lab2.DAL.Models;
using Lab2.DTO.SparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.BLL.Interfaces.Services
{
    public interface ISparePartsService
    {
        Task<IEnumerable<SparePartDto>> GetAll();
        Task<SparePartDto> GetById(Guid id);
        Task Create(SparePartForCreationDto entityForCreation);
        Task Create(IEnumerable<SparePart> entityForCreation);
        Task Delete(Guid id);
        Task Update(Guid id, SparePartForUpdateDto entityForUpdate);
    }
}
