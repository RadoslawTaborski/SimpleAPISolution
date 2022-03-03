using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Models;
public class TestContext : DbContext
{
    public DbSet<Status> Statuses => Set<Status>();

    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {}
}