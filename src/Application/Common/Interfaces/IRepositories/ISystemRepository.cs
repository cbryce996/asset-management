using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.System;

namespace AssetManagement.Application.Common.Interfaces.IRepositories
{
    public interface ISystemRepository : IRepository<SystemEntity>
    {
        bool Update(SystemEntity _system);
    }
}