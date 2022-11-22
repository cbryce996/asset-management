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

        public bool Add(T entity)
        {
            dbSet.Add(entity);
            return true;
        }

        public virtual IEnumerable<T> All()
        {
            return dbSet.ToList();
        }

        public T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual bool Remove(T entity)
        {
           dbSet.Remove(entity);
           return true;
        }

        public virtual bool Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}