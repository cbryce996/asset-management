using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Application.Common.Interfaces.IRepositories;
using AssetManagement.Domain.Software;
using AssetManagement.Infrastructure.Persistence;

using Microsoft.Extensions.Logging;

namespace AssetManagement.Infrastructure.Repositories
{
    public class SoftwareRepository : Repository<SoftwareEntity>, ISoftwareRepository
    {
         public SoftwareRepository(ApplicationDbContext _context, ILogger _logger) : base(_context, _logger)
        {
        }

        public override IEnumerable<SoftwareEntity> All()
        {
            try
            {
                return dbSet.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(SoftwareRepository));
                return new List<SoftwareEntity>();
            }
        }
    }
}