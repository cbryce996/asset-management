using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Common.Interfaces.IRepositories;
using AssetManagement.Domain.Install;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace AssetManagement.Infrastructure.Repositories
{
    public class InstallRepository : Repository<InstallEntity>, IInstallRepository
    {
        public InstallRepository(ApplicationDbContext _context, ILogger _logger) : base(_context, _logger)
        {
        }
    }
}