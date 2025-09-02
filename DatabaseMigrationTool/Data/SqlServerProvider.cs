using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabaseMigrationTool.Data
{
    public class SqlServerProvider : IDatabaseProvider
    {
        private readonly IConfiguration _configuration;

        public SqlServerProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = _configuration.GetConnectionString("SqlServer");
            optionsBuilder.UseSqlServer(connectionString);
            return optionsBuilder.Options;
        }
    }
}
