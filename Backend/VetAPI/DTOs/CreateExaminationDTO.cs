namespace VetAPI.DTOs
{
    public class CreateExaminationDTO
    {
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string Treatment { get; set; } = string.Empty;
        public string Prescription { get; set; } = string.Empty;
    }
}
