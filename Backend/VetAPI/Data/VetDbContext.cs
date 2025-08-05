using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace VetAPI.Data
{
    public class VetDbContext : DbContext
    {
        public VetDbContext(DbContextOptions<VetDbContext> options) : base(options) { }

        public DbSet<Examination> Examinations{ get; set; }
        public DbSet<Vet> Vets { get; set; }
    }
}
