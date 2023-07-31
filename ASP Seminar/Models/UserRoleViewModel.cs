namespace ASP_Seminar.Models
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel() {
            Roles = new List<RoleVM>();
        }
        public string UserId { get; set; }
        public string Email { get; set; }
        public List<RoleVM> Roles { get; set; }
    }
    public class RoleVM
    {
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
