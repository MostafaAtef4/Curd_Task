using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tasknew.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }

        [ForeignKey("MenuItemId")]
        public virtual MenuItem? MenuItem { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
    }
}
