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
        Task CompleteAsync();
    }
}