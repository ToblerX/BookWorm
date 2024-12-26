using System.ComponentModel.DataAnnotations;

namespace BookWorm.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        // Change Price from decimal to float
        public float Price { get; set; } = 0f; // Default value of 0f for float

        public string Description { get; set; } = string.Empty;

        [Display(Name = "Image")]
        public string ImageUrl { get; set; } = string.Empty; // New property
    }
}
