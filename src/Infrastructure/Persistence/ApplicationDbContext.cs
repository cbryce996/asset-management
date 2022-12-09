/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using Microsoft.EntityFrameworkCore;
using AssetManagement.Domain.System;
using System.Globalization;
using AssetManagement.Domain.System.ValueObjects;
using AssetManagement.Domain.User;

namespace AssetManagement.Infrastructure.Persistence
{
    /*
    * DbContext represents the database which Entity Framework will use
    * Contains connection and configuration information about the database.
    */

    public class ApplicationDbContext : DbContext
    {
        /* DbSet represents a table within the database  */
        /* Will be built by Entity Framework according to entity type  */
        public virtual DbSet<SystemEntity> SystemTable  { get; set; }
        public virtual DbSet<UserEntity> UserTable { get; set; }

        /* Captures default options from base DbContext declared in startup.cs */
        /* Can override options here for other databases  */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        /* Overrides the OnModelCreating method with custom configuration options */
        /* Necessary for Entity Framework to work with Domain layer */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* Tell Entity Framework which Entities own each Value Objects */
            builder.Entity<SystemEntity>().OwnsOne(x => x.Name);
            builder.Entity<SystemEntity>().OwnsOne(x => x.Ip);
            builder.Entity<SystemEntity>().OwnsOne(x => x.Mac);
            builder.Entity<SystemEntity>().OwnsMany(x => x.InstalledSoftware);
        }
    }
}