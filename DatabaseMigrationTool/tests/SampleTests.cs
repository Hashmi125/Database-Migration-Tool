using Xunit;
using DatabaseMigrationTool.Data;
using DatabaseMigrationTool.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class SampleTests
{
    [Fact]
    public void CanAddSampleEntity()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using var context = new ApplicationDbContext(options);
        context.SampleEntities.Add(new SampleEntity { Name = "Test" });
        context.SaveChanges();

        Assert.Equal(1, context.SampleEntities.Count());
        Assert.Equal("Test", context.SampleEntities.First().Name);
    }
}
