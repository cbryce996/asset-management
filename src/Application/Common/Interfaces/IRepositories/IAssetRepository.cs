/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using System.Threading.Tasks;
using AssetManagement.Domain.Entities;

namespace AssetManagement.Application.Common.Interfaces
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        // Unique method to Asset repository
    }
}