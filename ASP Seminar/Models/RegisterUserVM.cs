using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Seminar.Models
{
    [NotMapped]
    public class RegisterUserVM
    {
        public RegisterUserVM () {
            Roles = new List<RoleVM>();
        }

        [Required]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<RoleVM> Roles { get; set; }

    }
}
