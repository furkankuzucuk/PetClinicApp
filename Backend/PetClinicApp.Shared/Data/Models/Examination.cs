namespace PetClinicApp.Shared.Data.Models
{
    public class Examination
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string Diagnosis { get; set; } = string.Empty;    // Tanı
        public string Treatment { get; set; } = string.Empty;    // Tedavi açıklaması
        public string Prescription { get; set; } = string.Empty; // Reçete edilen ilaçlar

        // Optional: Navigation (Pet ilişkisi)
        // public Pet? Pet { get; set; }
    }
}
