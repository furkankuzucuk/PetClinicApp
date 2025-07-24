using Microsoft.EntityFrameworkCore;
using NotifyAPI.Data.Models;

namespace NotifyAPI.Data
{
    public class NotifyDbContext : DbContext
    {
        public NotifyDbContext(DbContextOptions<NotifyDbContext> options) : base(options) { }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Notification>()
                .HasOne<NotificationType>()
                .WithMany()
                .HasForeignKey(n => n.NotificationTypeId);
        }
    }
}
