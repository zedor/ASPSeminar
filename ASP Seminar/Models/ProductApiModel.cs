namespace ASP_Seminar.Models
{
    public class ProductApiModel
    {
        public ProductApiModel()
        {
            Categories = new List<string>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool? HasImage { get; set; }
        public List<string> Categories { get; set; }
    }
}
