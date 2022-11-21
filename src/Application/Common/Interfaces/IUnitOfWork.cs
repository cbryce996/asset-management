/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using AssetManagement.Application.Common.Interfaces.IRepositories;

namespace AssetManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISoftwareRepository SoftwareRepository { get; set; }
        ISystemRepository SystemRepository { get; set; }

        // Sends changes to database
        void Complete();
    }
}