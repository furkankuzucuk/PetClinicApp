namespace PetClinicApp.Shared.Data.Models
{
    public class UserRoleJoin
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public Role Role { get; set; }
    }
}
