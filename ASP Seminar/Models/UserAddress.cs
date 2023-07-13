using System.ComponentModel.DataAnnotations;

namespace ASP_Seminar.Models
{
    public class UserAddress
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number is not valid.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        [StringLength(150)]
        public string? Address { get; set; }
        [Required(ErrorMessage = "City is required.")]
        [StringLength(50)]
        public string? City { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50)]
        public string? Country { get; set; }
        [Required(ErrorMessage = "Postal code is required.")]
        [StringLength(20)]
        public string? ZipCode { get; set; }
    }
}
