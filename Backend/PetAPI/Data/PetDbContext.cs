using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace PetAPI.Data
{
    public class PetDbContext : DbContext
    {
        public PetDbContext(DbContextOptions<PetDbContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
    }
}
