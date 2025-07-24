using Microsoft.EntityFrameworkCore;
using PetAPI.Data.Models;

namespace PetAPI.Data
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options)
        {

        }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Vaccine>()
                .HasOne(v => v.Animal)
                .WithMany(a => a.Vaccines)
                .HasForeignKey(v => v.AnimalId)
                .OnDelete(DeleteBehavior.Cascade); 

            
            modelBuilder.Entity<Vaccine>()
                .HasOne(v => v.VaccineType)
                .WithMany(vt => vt.Vaccines)
                .HasForeignKey(v => v.VaccineTypeId)
                .OnDelete(DeleteBehavior.Restrict);  //Bir tabloyla ilişki içinde olduğu için silme işlemini engeller.
        }
    }
}