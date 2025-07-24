namespace SystemAPI.Data.Models
{
    public class Examination
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VeterinarianId { get; set; }
        public DateTime Date { get; set; }
        public string Complaint { get; set; } = string.Empty;
    }
}