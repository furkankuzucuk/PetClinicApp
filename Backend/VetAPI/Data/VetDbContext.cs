using Microsoft.EntityFrameworkCore;
using VetAPI.Data.Models;

namespace VetAPI.Data
{
    public class VetDbContext : DbContext
    {
        public VetDbContext(DbContextOptions<VetDbContext> options) : base(options) { }

        public DbSet<Veterinarian> Veterinarians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Veterinarian>()
                .HasIndex(v => v.UserId)
                .IsUnique(); 
        }
    }
}
