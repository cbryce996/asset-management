using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using project_cbryce996.Core.IRepositories;
using project_cbryce996.Data;
using project_cbryce996.Models;

namespace project_cbryce996.Core.Repositories
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(ApplicationDbContext _context, ILogger _logger) : base(_context, _logger)
        {
            dbSet = context.Assets;
        }

        public override async Task<IEnumerable<Asset>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(AssetRepository));
                return new List<Asset>();
            }
        }

        public override async Task<bool> Upsert(Asset entity)
        {
            try {
                var existingAsset = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingAsset == null)
                {
                    return await Add(entity);
                }

                existingAsset.SystemName = entity.SystemName;
                existingAsset.Model = entity.Model;
                existingAsset.Ip = entity.Ip;
                existingAsset.Manufacturer = entity.Manufacturer;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(AssetRepository));
                return false;
            }
        }

        public override async Task<bool> Remove(Guid id)
        {
            try {
                var existingAsset = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (existingAsset != null) 
                {
                    dbSet.Remove(existingAsset);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(AssetRepository));
                return false;
            }
        }
    }
}