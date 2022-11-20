/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using Microsoft.Extensions.Logging;

using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Application.Common.Interfaces.IRepositories;
using AssetManagement.Infrastructure.Repositories;

namespace AssetManagement.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public ISoftwareRepository SoftwareRepository { get; private set; }
        public ISystemRepository SystemRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            SoftwareRepository = new SoftwareRepository(_context, _logger);
            SystemRepository = new SystemRepository(_context, _logger);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}