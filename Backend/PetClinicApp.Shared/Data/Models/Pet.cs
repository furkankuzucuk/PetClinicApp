namespace PetClinicApp.Shared.Data.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public int UserId { get; set; } // FK to User in AuthAPI
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ChipNumber { get; set; }
    }
}
