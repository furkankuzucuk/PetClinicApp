using AuthAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace AuthAPI.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        } 
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; } //db tablo oluşturma

        protected override void OnModelCreating(ModelBuilder modelBuilder)  //fk ayarlarını yapma
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)   
            .WithMany(r => r.Users)   //Kullanıcının işlemleri
            .HasForeignKey(u => u.RoleId);
        }
    }
}