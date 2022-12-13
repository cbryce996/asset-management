/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using System.Threading.Tasks;
using AssetManagement.Application.Common.Interfaces.IRepositories;

namespace AssetManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISystemRepository SystemRepository { get; set; }
        
        IUserRepository UserRepository { get; set; }

        Task<bool> Complete();
    }
}