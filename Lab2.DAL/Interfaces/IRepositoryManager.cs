using Lab2.DAL.Interfaces.Repositories;

namespace Lab2.DAL.Interfaces
{
    public interface IRepositoryManager
    {
        IFaultsRepository FaultsRepository { get; }
        IRepairingModelsRepository RepairingModelsRepository { get; }
        ISparePartsRepository SparePartsRepository { get; }
        IUsedSparePartsRepository UsedSparePartsRepository { get; }
    }
}
