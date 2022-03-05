using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace SimpleAPI.Models;
public class TestContext : DbContext
{
    private ILogger _logger;

    public DbSet<Status> Statuses => Set<Status>();

    public TestContext(ILogger logger, DbContextOptions<TestContext> options) : base(options)
    { 
        this._logger = logger;
        _logger.Information("Migrations just started.");
        this.Database.MigrateAsync();
        _logger.Information("Migrations just finished.");
    }
}