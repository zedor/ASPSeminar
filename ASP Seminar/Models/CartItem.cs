using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_Seminar.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public decimal GetTotal()
        {
            if (Product == null) throw new NullReferenceException();
            return Product.Price * Quantity;
        }
    }
}
