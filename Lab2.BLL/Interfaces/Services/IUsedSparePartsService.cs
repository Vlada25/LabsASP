using Lab2.DAL.Models;
using Lab2.DTO.UsedSparePart;

namespace Lab2.BLL.Interfaces.Services
{
    public interface IUsedSparePartsService
    {
        Task<IEnumerable<UsedSparePartDto>> GetAll();
        Task<IEnumerable<UsedSparePartDto>> Get(int rowsCount, string cacheKey);
        Task<UsedSparePartDto> GetById(Guid id);
        Task Create(UsedSparePartForCreationDto entityForCreation);
        Task Create(IEnumerable<UsedSparePart> entityForCreation);
        Task Delete(Guid id);
        Task Update(Guid id, UsedSparePartForUpdateDto entityForUpdate);
    }
}
