using Microsoft.EntityFrameworkCore;
using SystemAPI.Data.Models;

namespace SystemAPI.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Examination>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Prescription>()
                .HasOne<Examination>()
                .WithMany()
                .HasForeignKey(p => p.ExaminationId);

          
            modelBuilder.Entity<Prescription>()
                .HasOne<Medication>()
                .WithMany()
                .HasForeignKey(p => p.MedicationId);
        }
    }
}
