using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace project_cbryce996.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Generic methods available to all repository
        Task<IEnumerable<T>> All();
        Task<T> Get(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Remove(Guid id);
        Task<bool> Upsert(T entity);
    }
}