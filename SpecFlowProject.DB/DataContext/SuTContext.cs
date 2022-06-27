using SpecFlowProject.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace SpecFlowProject.DB.DataContext
{
    public class SuTContext : DbContext
    {
        public SuTContext(DbContextOptions<SuTContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>();
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
