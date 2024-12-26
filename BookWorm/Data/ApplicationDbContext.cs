using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookWorm.Models;

namespace BookWorm.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Profile> Profiles { get; set; }  // Add the Profile DbSet
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships, if needed
            modelBuilder.Entity<Profile>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Profile>(p => p.UserId);

            // Add test data for books
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 10.99m, Description = "Classic novel set in the 1920s.", ImageUrl = "https://i.etsystatic.com/20545894/r/il/7d8e6d/1977091569/il_570xN.1977091569_fv4f.jpg" },
                new Book { Id = 2, Title = "1984", Author = "George Orwell", Price = 8.99m, Description = "Dystopian novel about a totalitarian regime.", ImageUrl = "https://m.media-amazon.com/images/I/61ZewDE3beL.jpg" },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 7.99m, Description = "A novel about racial injustice in the American South.", ImageUrl = "https://cdn.britannica.com/21/182021-050-666DB6B1/book-cover-To-Kill-a-Mockingbird-many-1961.jpg" }
            );
        }
    }
}
