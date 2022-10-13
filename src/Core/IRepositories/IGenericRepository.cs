using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace project_cbryce996.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Generic methods available to all repository
        IEnumerable<T> All();
        T Get(Guid id);
        bool Add(T entity);
        bool Remove(Guid id);
        bool Upsert(T entity);
    }
}