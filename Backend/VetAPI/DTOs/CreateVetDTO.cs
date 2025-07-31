namespace VetAPI.DTOs
{
    public class CreateVetDTO
    {
        public int UserId { get; set; }
        public string DiplomaNumber { get; set; }
        public string University { get; set; }
        public int GraduationYear { get; set; }
        public string Specialization { get; set; }
    }
}
