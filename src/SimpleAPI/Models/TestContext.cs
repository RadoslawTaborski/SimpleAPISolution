using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace SimpleAPI.Models;
public class TestContext : DbContext
{
    private readonly ILogger _logger;

    public DbSet<Status> Statuses => Set<Status>();

    public TestContext(ILogger logger, DbContextOptions<TestContext> options) : base(options)
    { 
        this._logger = logger;
        _logger.Information("Migrations just started.");
        this.Database.Migrate();
        _logger.Information("Migrations just finished.");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        base.OnModelCreating(modelBuilder);
    }
}