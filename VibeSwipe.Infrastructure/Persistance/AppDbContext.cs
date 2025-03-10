using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VibeSwipe.Domain.Entities;

namespace VibeSwipe.Infrastructure.Persistance
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        
        private readonly IConfiguration _config;        

        public AppDbContext(IConfiguration config, DbContextOptions options) : base (options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(_config.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(_config.GetConnectionString("DefaultConnection")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
