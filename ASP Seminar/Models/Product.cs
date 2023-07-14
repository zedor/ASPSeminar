using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_Seminar.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }

        public bool? HasImage { get; set; }

        [NotMapped]
        public IFormFile? ImgFile { get; set; }

        [ForeignKey("ProductId")]
        public List<ProductCategory>? ProductCategories { get; set; }


        [ForeignKey("ProductId")]
        public List<OrderItem>? OrderItems { get; set; }
    }
}
