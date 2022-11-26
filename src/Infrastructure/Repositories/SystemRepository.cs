using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Application.Common.Interfaces.IRepositories;
using AssetManagement.Domain.System;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace AssetManagement.Infrastructure.Repositories
{
    public class SystemRepository : Repository<SystemEntity>, ISystemRepository
    {
        public SystemRepository(ApplicationDbContext _context, ILogger _logger) : base(_context, _logger)
        {
        }

        public bool Update(SystemEntity _system)
        {
            if (dbSet.Any(x => x.Id == _system.Id))
            {
                dbSet.Update(_system);
                return true;
            }

            return false;
        }
    }
}