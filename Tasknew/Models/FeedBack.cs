using System.ComponentModel.DataAnnotations;

namespace Tasknew.Models
{
    public class FeedBack
    {
        [Key]
        public int Id { get; set; }
        public required string CustomerName { get; set; }

        public string? Email { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public required int Rating { get; set; }

        public required string Comments { get; set; }


        public DateTime DateSubmitted { get; set; }

    }
}
