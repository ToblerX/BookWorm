using Microsoft.AspNetCore.Identity;

namespace BookWorm.Models
{
    public class Cart
    {
        public int Id { get; set; }  // Unique identifier for the cart entry
        public string UserId { get; set; }  // Foreign key for the user making the purchase
        public int BookId { get; set; }  // Foreign key for the purchased book
        public string BookName { get; set; }  // Name of the book purchased
        public decimal Price { get; set; }  // Price of the book at the time it was added to the cart

        // Navigation properties
        public virtual IdentityUser User { get; set; }  // Navigation property to the IdentityUser
        public virtual Book Book { get; set; }  // Navigation property to the Book entity
    }
}
