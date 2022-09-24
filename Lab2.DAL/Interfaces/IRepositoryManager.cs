using Lab2.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
