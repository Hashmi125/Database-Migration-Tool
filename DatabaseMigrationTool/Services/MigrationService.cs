using System;
using Microsoft.EntityFrameworkCore;
using DatabaseMigrationTool.Data;

namespace DatabaseMigrationTool.Services
{
    public class MigrationService
    {
        private readonly IDatabaseProvider _databaseProvider;
        private ApplicationDbContext _context;

        public MigrationService(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
            var options = _databaseProvider.GetDbContextOptions();
            _context = new ApplicationDbContext(options);
        }

        public void Migrate()
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Apply migrations
                _context.Database.Migrate();

                // Example: Seed data or synchronize data here
                // _context.SampleEntities.Add(new Models.SampleEntity { Name = "Example" });
                // _context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            // Rollback logic depends on your migration strategy.
            // EF Core migrations are not transactional by default.
            // You can implement custom rollback or use backups.
            Console.WriteLine("Rollback is not implemented. Please implement backup/restore strategy.");
        }
    }
}
