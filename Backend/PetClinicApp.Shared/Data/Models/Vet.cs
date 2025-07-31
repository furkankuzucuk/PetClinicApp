namespace PetClinicApp.Shared.Data.Models
{
    public class Vet
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // AuthAPI'deki kullanıcıyı temsil eder
        public string DiplomaNumber { get; set; }
        public string University { get; set; }
        public int GraduationYear { get; set; }
        public string Specialization { get; set; }
    }
}
