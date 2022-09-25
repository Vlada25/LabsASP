using Lab2.DAL.Interfaces;
using Lab2.DAL.Interfaces.Repositories;
using Lab2.DAL.Repositories;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _memoryCache;

        private IFaultsRepository _faultsRepository;
        private IRepairingModelsRepository _repairingModelsRepository;
        private ISparePartsRepository _sparePartsRepository;
        private IUsedSparePartsRepository _usedSparePartsRepository;

        public RepositoryManager(AppDbContext dbContext, IMemoryCache memoryCache)
        {
            _dbContext = dbContext;
            _memoryCache = memoryCache;
        }


        public IFaultsRepository FaultsRepository
        {
            get
            {
                if (_faultsRepository == null)
                {
                    _faultsRepository = new FaultsRepository(_dbContext, _memoryCache);
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
                    _sparePartsRepository = new SparePartsRepository(_dbContext, _memoryCache);
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
                    _repairingModelsRepository = new RepairingModelsRepository(_dbContext, _memoryCache);
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
                    _usedSparePartsRepository = new UsedSparePartsRepository(_dbContext, _memoryCache);
                }
                return _usedSparePartsRepository;
            }
        }
    }
}
