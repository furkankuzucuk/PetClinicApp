namespace PetAPI.Data.Models
{
    public class VaccineType
    {
        public int Id { get; set; }
        public string VaccineName { get; set; }
        public virtual ICollection<Vaccine> Vaccines{ get; set; }
    }
}