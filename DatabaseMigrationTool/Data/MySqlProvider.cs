using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabaseMigrationTool.Data
{
    public class MySqlProvider : IDatabaseProvider
    {
        private readonly IConfiguration _configuration;

        public MySqlProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = _configuration.GetConnectionString("MySql");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return optionsBuilder.Options;
        }
    }
}
