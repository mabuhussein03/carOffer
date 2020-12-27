using Microsoft.EntityFrameworkCore;
using WMI_NetCore_API.Core.Models;
namespace WMI_NetCore_API.Persistence
{
    public class WMIDbContext : DbContext
    {
        public DbSet<WMIModel> WMI { get; set; }

        public WMIDbContext(DbContextOptions<WMIDbContext> options)
          : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=WMI_DB.db;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WMIModel>().ToTable("WMI");
        }
    }
}