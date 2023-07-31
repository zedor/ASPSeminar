using Microsoft.Build.Framework;

namespace ASP_Seminar.Models
{
    public class ProductVM
    {
        public ProductVM()
        {
            Categories = new List<CategoryVM>();
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool? HasImage { get; set; }
        [Required]
        public IFormFile? ImgFile { get; set; }
        public List<CategoryVM> Categories { get; set; }
    }

    public class CategoryVM
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public bool Selected { get; set; }
    }
}
