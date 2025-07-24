namespace SystemAPI.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int UserId { get; set; } 
        public int VeterinarianId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
