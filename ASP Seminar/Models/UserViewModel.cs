using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Seminar.Models
{
    [NotMapped]
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
