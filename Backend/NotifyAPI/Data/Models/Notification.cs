namespace NotifyAPI.Data.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NotificationTypeId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
