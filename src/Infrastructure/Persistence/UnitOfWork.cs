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
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Persistence
{
    /*
    * Implements the UnitOfWork pattern using DbContext
    */

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public ISystemRepository SystemRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            SystemRepository = new SystemRepository(_context, _logger);
            UserRepository = new UserRepository(_context, _logger);
        }

        public async Task<bool> Complete()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}