namespace VaccinationAPI.DTOs
{
    public class CreateVaccinationDTO
    {
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public int VaccineTypeId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool RequiresRepeat { get; set; }
        public int? RepeatAfterDays { get; set; }
    }
}
