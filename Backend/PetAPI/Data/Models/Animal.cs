namespace PetAPI.Data.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ChipNunmber { get; set; }

        public int UserId { get; set; }
        public virtual ICollection<Vaccine>Vaccines { get; set; }
       

    }
}