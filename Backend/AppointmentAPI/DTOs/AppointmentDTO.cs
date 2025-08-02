namespace AppointmentAPI.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PetId { get; set; }
        public int VetUserId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
