using Microsoft.EntityFrameworkCore;
using PetClinicApp.Shared.Data.Models;

namespace AppointmentAPI.Data
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
            : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VetWorkingHour> VetWorkingHours { get; set; }

    }
}
