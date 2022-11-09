/*
    Repository Pattern adapted from https://www.youtube.com/watch?v=-jcf1Qq8A-4
    Author: Mohamad Lawand
    Date: 01/11/2022
*/

using Microsoft.EntityFrameworkCore;
using project_cbryce996.Models;

namespace project_cbryce996.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Asset> Assets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}