using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabaseMigrationTool.Data
{
    public class PostgreSqlProvider : IDatabaseProvider
    {
        private readonly IConfiguration _configuration;

        public PostgreSqlProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = _configuration.GetConnectionString("PostgreSql");
            optionsBuilder.UseNpgsql(connectionString);
            return optionsBuilder.Options;
        }
    }
}
