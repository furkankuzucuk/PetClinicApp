namespace PetClinicApp.Shared.Data.Models
{
    public class VetWorkingHour
    {
        public int Id { get; set; }
        public int VetUserId { get; set; }
        public DateTime StartTime { get; set; } // Örn: 2025-08-01 09:00
        public DateTime EndTime { get; set; }   // Örn: 2025-08-01 17:00
    }
}
