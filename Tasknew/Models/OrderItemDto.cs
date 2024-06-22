namespace Tasknew.Models
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public string? MenuItemName { get; set; }
    }
}
