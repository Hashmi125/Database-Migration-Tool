using Microsoft.EntityFrameworkCore;
using DatabaseMigrationTool.Models;

namespace DatabaseMigrationTool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SampleEntity> SampleEntities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Optional: override OnModelCreating for model configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add model configurations here if needed
        }
    }
}
