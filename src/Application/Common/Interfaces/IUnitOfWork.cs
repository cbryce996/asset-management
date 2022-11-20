/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/


using AssetManagement.Application.Common.Interfaces.IRepositories;

namespace AssetManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IInstallRepository InstallRepository { get; }
        ISystemRepository SystemRepository { get; }
        ISoftwareRepository SoftwareRepository { get; }

        // Sends changes to database
        void Complete();
    }
}