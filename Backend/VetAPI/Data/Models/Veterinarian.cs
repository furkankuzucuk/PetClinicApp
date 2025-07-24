namespace VetAPI.Data.Models
{
    public class Veterinarian
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DiplomaNumber { get; set; } = string.Empty;
        public string GraduationUniversity { get; set; } = string.Empty;
        public int GraduationYear { get; set; }
        public string Specialization { get; set; }

    }
}