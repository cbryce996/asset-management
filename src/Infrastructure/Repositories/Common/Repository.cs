/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using AssetManagement.Application.Common.Interfaces;
using AssetManagement.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public Repository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            this.dbSet = context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async virtual IAsyncEnumerable<T> All()
        {
            foreach (var x in await dbSet.ToListAsync())
            {
                yield return x;
            }
        }

        public async virtual Task<T> Get(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual bool Remove(T entity)
        {
           dbSet.Remove(entity);
           return true;
        }
    }
}