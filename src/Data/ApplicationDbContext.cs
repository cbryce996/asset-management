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