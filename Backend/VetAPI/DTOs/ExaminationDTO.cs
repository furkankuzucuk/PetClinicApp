namespace VetAPI.DTOs
{
    public class ExaminationDTO
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public string Prescription { get; set; }
    }
}
