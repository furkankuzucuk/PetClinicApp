namespace PetClinicApp.Shared.Data.Models
{
    public class Vaccination
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public int VaccineTypeId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool RequiresRepeat { get; set; }
        public int? RepeatAfterDays { get; set; } // örn: 365
        public DateTime? NextDate { get; set; }
    }
}
