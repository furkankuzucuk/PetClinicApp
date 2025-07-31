namespace PetAPI.DTOs
{
    public class CreatePetDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ChipNumber { get; set; }
    }
}
