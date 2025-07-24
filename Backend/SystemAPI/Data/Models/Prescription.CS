namespace SystemAPI.Data.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int ExaminationId { get; set; }
        public int MedicationId { get; set; }
        public float Dosage { get; set; }
        public string UsageDuration { get; set; } = string.Empty;
    }
}