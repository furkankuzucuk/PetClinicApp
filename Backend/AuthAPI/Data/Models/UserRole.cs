namespace AuthAPI.Data.Models
{
    public class UserRole
    {
        public int Id { get; set; } 
        public string RoleName { get; set; } 
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}