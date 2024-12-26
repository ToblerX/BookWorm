using Microsoft.AspNetCore.Identity;

namespace BookWorm.Models
{
    public class Cart
    {
        public int Id { get; set; }  // Unique identifier for the cart entry
        public string UserId { get; set; }  // Foreign key for the user making the purchase
        public int BookId { get; set; }  // Foreign key for the purchased book
        public string BookName { get; set; }  // Name of the book purchased

        // Navigation properties
        public virtual IdentityUser User { get; set; }  // Navigation property to the IdentityUser
        public virtual Book Book { get; set; }  // Navigation property to the Book entity
    }
}
