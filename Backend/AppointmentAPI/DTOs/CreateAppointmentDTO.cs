namespace AppointmentAPI.DTOs
{
    public class CreateAppointmentDTO
    {
        public int UserId { get; set; }
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
