namespace Tasknew.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; } = 0;
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
