using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Model
{
    public class TestContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}