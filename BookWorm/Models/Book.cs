using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;
        public string Description { get; set; } = string.Empty;
        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = string.Empty; // New property
    }
}
