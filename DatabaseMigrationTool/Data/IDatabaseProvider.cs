using Microsoft.EntityFrameworkCore;

namespace DatabaseMigrationTool.Data
{
    public interface IDatabaseProvider
    {
        DbContextOptions<ApplicationDbContext> GetDbContextOptions();
    }
}
