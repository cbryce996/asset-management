/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using AssetManagement.Domain.Entities;
using AssetManagement.Application.Common.Interfaces;

namespace AssetManagement.Infrastructure.Persistence
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