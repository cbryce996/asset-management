/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project_cbryce996.Core.IRepositories;

namespace project_cbryce996.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IAssetRepository Assets { get; }

        // Sends changes to database
        void Complete();
    }
}