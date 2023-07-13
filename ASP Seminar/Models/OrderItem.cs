using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_Seminar.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(9,2)")]
        public decimal Total { get; set; }

        [NotMapped]
        public string? ProductTitle { get; set; }
    }
}
