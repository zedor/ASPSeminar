using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Seminar.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Total price is required!")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Total { get; set; }
        public int? Discount { get; set; }



        public string? Message { get; set; }

        public string? UserId { get; set; }

        [ForeignKey("BillingAddressId")]
        public UserAddress? BillingAddress { get; set; }

        [ForeignKey("ShippingAddressId")]
        public UserAddress? ShippingAddress { get; set; }
        

        [ForeignKey("OrderId")]
        public List<OrderItem>? OrderItems { get; set; }
    }
}
