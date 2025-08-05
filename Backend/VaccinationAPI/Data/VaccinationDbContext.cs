using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace VaccinationAPI.Data
{
    public class VaccinationDbContext : DbContext
    {
        public VaccinationDbContext(DbContextOptions<VaccinationDbContext> options)
            : base(options) { }

        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<VaccineType> VaccineTypes { get; set; }
    }
}
