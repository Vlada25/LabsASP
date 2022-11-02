using Lab2.DAL.Models;
using Lab2.DTO.RepairingModel;

namespace Lab2.BLL.Interfaces.Services
{
    public interface IRepairingModelsService
    {
        Task<IEnumerable<RepairingModelDto>> GetAll();
        Task<IEnumerable<RepairingModelDto>> Get(int rowsCount, string cacheKey);
        Task<RepairingModelDto> GetById(Guid id);
        Task Create(RepairingModelForCreationDto entityForCreation);
        Task Create(IEnumerable<RepairingModel> entityForCreation);
        Task Delete(Guid id);
        Task Update(Guid id, RepairingModelForUpdateDto entityForUpdate);
    }
}
