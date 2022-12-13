using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AssetManagement.Domain.System;
using AssetManagement.Domain.User;

namespace AssetManagement.Application.Common.Interfaces.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        bool Update(UserEntity _user);

        UserEntity GetEntity(UserEntity entity);
    }
}