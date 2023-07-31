using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public int Quantity { get; set; }
        [Required]
        [Column(TypeName = "decimal(9,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public bool? HasImage { get; set; }

        [NotMapped]
        public IFormFile? ImgFile { get; set; }

        [ForeignKey("ProductId")]
        [DisplayName("Categories")]
        public List<ProductCategory>? ProductCategories { get; set; }


        [ForeignKey("ProductId")]
        public List<OrderItem>? OrderItems { get; set; }
    }
}
