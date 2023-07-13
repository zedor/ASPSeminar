namespace ASP_Seminar.Models
{
    public class CartItem
    {
        public Product? Product { get; set; }
        public decimal Quantity { get; set; }

        public decimal GetTotal()
        {
            if (Product == null) throw new NullReferenceException();
            return Product.Price * Quantity;
        }
    }
}
