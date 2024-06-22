using System.ComponentModel.DataAnnotations;

namespace Tasknew.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public string? Category { get; set; }
        public bool Available { get; set; } = true;
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }

        
    }
}
