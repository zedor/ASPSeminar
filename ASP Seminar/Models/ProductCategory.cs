using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Seminar.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ProductId { get; set; }

        [NotMapped]
        public string? ProductTitle { get; set; }
        [NotMapped]
        public string? CategoryTitle { get; set; }
    }
}
