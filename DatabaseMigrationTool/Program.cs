using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DatabaseMigrationTool.Data;
using DatabaseMigrationTool.Services;

class Program
{
    static void Main(string[] args)
    {
        // Setup configuration
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Setup DI
        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);

        // Register database provider based on config
        var providerName = configuration["DatabaseProvider"];
        switch (providerName)
        {
            case "SqlServer":
                services.AddSingleton<IDatabaseProvider, SqlServerProvider>();
                break;
            case "MySql":
                services.AddSingleton<IDatabaseProvider, MySqlProvider>();
                break;
            case "PostgreSql":
                services.AddSingleton<IDatabaseProvider, PostgreSqlProvider>();
                break;
            default:
                throw new Exception("Unsupported database provider");
        }

        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<MigrationService>();
        services.AddScoped<ValidationService>();

        var serviceProvider = services.BuildServiceProvider();

        var migrationService = serviceProvider.GetRequiredService<MigrationService>();
        var validationService = serviceProvider.GetRequiredService<ValidationService>();

        try
        {
            Console.WriteLine("Starting data validation before migration...");
            validationService.ValidateDataBeforeMigration();

            Console.WriteLine("Starting migration...");
            migrationService.Migrate();

            Console.WriteLine("Validating data after migration...");
            validationService.ValidateDataAfterMigration();

            Console.WriteLine("Migration completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Migration failed: {ex.Message}");
            Console.WriteLine("Rolling back...");
            migrationService.Rollback();
            Console.WriteLine("Rollback completed.");
        }
    }
}
