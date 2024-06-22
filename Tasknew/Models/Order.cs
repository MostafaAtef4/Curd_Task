using System.ComponentModel.DataAnnotations;

namespace Tasknew.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; } = 0;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
