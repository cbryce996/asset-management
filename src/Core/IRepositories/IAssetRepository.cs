/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using System.Threading.Tasks;
using project_cbryce996.Models;

namespace project_cbryce996.Core.IRepositories
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        // Unique method to Asset repository
    }
}