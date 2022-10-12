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
using System.Collections.Immutable;

namespace project_cbryce996.Core.Repositories
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(ApplicationDbContext _context, ILogger _logger) : base(_context, _logger)
        {
        }

        public override IEnumerable<Asset> All()
        {
            try
            {
                return dbSet.ToList();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(AssetRepository));
                return new List<Asset>();
            }
        }

        /*
        public override bool Upsert(Asset entity)
        {
            try {
                var existingAsset = dbSet.Where(x => x.Id == entity.Id).FirstOrDefault();

                if (existingAsset == null)
                {
                    return Add(entity);
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
        }*/

        public override bool Remove(Guid id)
        {
            try {
                var existingAsset = dbSet.Where(x => x.Id == id).FirstOrDefault();

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