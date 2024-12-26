using Microsoft.AspNetCore.Identity;

namespace BookWorm.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string UserId { get; set; } // Foreign key to IdentityUser
        public string? FullName { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; } // Make nullable
        public string? PostAddress { get; set; }
        public string? ProfilePictureUrl { get; set; }

        // Navigation property to the user
        public virtual IdentityUser User { get; set; }
    }
}
