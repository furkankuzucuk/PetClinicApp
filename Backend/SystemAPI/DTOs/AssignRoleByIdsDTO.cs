namespace SystemAPI.DTOs
{
    public class AssignRoleByIdsDTO
    {
        public int RequesterUserId { get; set; }
        public int TargetUserId { get; set; }
        public int RoleId { get; set; }
    }
}
