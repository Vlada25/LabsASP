﻿using Lab2.DAL.Models;
using Lab2.DTO.SparePart;

namespace Lab2.BLL.Interfaces.Services
{
    public interface ISparePartsService
    {
        Task<IEnumerable<SparePartDto>> GetAll();
        Task<IEnumerable<SparePartDto>> Get(int rowsCount, string cacheKey);
        Task<SparePartDto> GetById(Guid id);
        Task Create(SparePartForCreationDto entityForCreation);
        Task Create(IEnumerable<SparePart> entityForCreation);
        Task Delete(Guid id);
        Task Update(Guid id, SparePartForUpdateDto entityForUpdate);
    }
}
