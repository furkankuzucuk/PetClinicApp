using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace SystemAPI.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleJoin> UserRoleJoins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRoleJoin>().ToTable("UserRoleJoins");

            modelBuilder.Entity<UserRoleJoin>()
                .HasKey(ur => new { ur.UserID, ur.RoleID });

            modelBuilder.Entity<UserRoleJoin>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoleJoins)
                .HasForeignKey(ur => ur.RoleID);
        }
    }
}
