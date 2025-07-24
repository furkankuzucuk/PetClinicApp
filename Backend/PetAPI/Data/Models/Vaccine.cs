namespace PetAPI.Data.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public DateTime ImplementationDate { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public int VaccineTypeId { get; set; }
        public VaccineType VaccineType { get; set; }

        public int VeterinarianId { get; set; }
    }
}