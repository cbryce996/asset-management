using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AssetManagement.Application.Auth.DTOs;
using AssetManagement.Application.Common.Interfaces.IRepositories;
using AssetManagement.Domain.System;
using AssetManagement.Domain.User;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace AssetManagement.Infrastructure.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationDbContext _context, ILogger _logger) : base(_context, _logger)
        {
        }

        public bool Update(UserEntity _user)
        {
            if (dbSet.Any(x => x.Id == _user.Id))
            {
                dbSet.Update(_user);
                return true;
            }

            return false;
        }

        /* TODO: Better handline of null response */
        public UserEntity GetEntity(UserEntity _user)
        {
            UserEntity userEntity = dbSet.Where(x => x.Username == _user.Username && x.Password == _user.Password).FirstOrDefault();

            if (userEntity != null)
            {
                return userEntity;
            }

            return new UserEntity();
        }
    }
}