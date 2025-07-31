using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace AuthAPI.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Kullanicilar");
        }
    }
}
