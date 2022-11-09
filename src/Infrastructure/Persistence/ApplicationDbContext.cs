/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using Microsoft.EntityFrameworkCore;

using AssetManagement.Domain.Entities;
using AssetManagement.Application.Common.Interfaces;

namespace AssetManagement.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Asset> Assets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}