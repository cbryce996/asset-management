/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AssetManagement.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Generic methods available to all repository
        IAsyncEnumerable<T> All();
        Task<T> Get(Guid id);
        Task<bool> Add(T entity);
        bool Remove(T entity);
    }
}