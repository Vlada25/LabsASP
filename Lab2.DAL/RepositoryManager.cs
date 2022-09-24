using Lab2.DAL.Interfaces;
using Lab2.DAL.Interfaces.Repositories;
using Lab2.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _dbContext;

        private IFaultsRepository _faultsRepository;
        private IRepairingModelsRepository _repairingModelsRepository;
        private ISparePartsRepository _sparePartsRepository;
        private IUsedSparePartsRepository _usedSparePartsRepository;

        public RepositoryManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IFaultsRepository FaultsRepository
        {
            get
            {
                if (_faultsRepository == null)
                {
                    _faultsRepository = new FaultsRepository(_dbContext);
                }
                return _faultsRepository;
            }
        }


        public ISparePartsRepository SparePartsRepository
        {
            get
            {
                if (_sparePartsRepository == null)
                {
                    _sparePartsRepository = new SparePartsRepository(_dbContext);
                }
                return _sparePartsRepository;
            }
        }

        public IRepairingModelsRepository RepairingModelsRepository
        {
            get
            {
                if (_repairingModelsRepository == null)
                {
                    _repairingModelsRepository = new RepairingModelsRepository(_dbContext);
                }
                return _repairingModelsRepository;
            }
        }

        public IUsedSparePartsRepository UsedSparePartsRepository
        {
            get
            {
                if (_usedSparePartsRepository == null)
                {
                    _usedSparePartsRepository = new UsedSparePartsRepository(_dbContext);
                }
                return _usedSparePartsRepository;
            }
        }
    }
}
