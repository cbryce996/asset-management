/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/


namespace AssetManagement.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IAssetRepository Assets { get; }

        // Sends changes to database
        void Complete();
    }
}