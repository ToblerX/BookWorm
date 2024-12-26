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
                new Book { Id = 3, Title = "To Kill a Mockingbird", Author = "Harper Lee", Price = 7.99m, Description = "A novel about racial injustice in the American South.", ImageUrl = "https://cdn.britannica.com/21/182021-050-666DB6B1/book-cover-To-Kill-a-Mockingbird-many-1961.jpg" },
                new Book { Id = 4, Title = "Crooked House", Author = "Agatha Christie", Price = 10.99m, Description = "A classic detective novel featuring Hercule Poirot.", ImageUrl = "https://m.media-amazon.com/images/I/714wbWkDOUL._AC_UF1000,1000_QL80_.jpg" },
                new Book { Id = 5, Title = "Murder of Roger Ackroyd", Author = "Agatha Christie", Price = 10.99m, Description = "One of the most famous and controversial Poirot mysteries.", ImageUrl = "https://m.media-amazon.com/images/I/61a0Vb1bjJL._AC_UF1000,1000_QL80_.jpg" },
                new Book { Id = 6, Title = "After the Funeral", Author = "Agatha Christie", Price = 11.99m, Description = "A Hercule Poirot mystery involving a family secret.", ImageUrl = "https://media.thuprai.com/__sized__/front_covers/after-the-funeral-9b55moz7-thumbnail-280x405-70.jpg" },
                new Book { Id = 7, Title = "Endless Night", Author = "Agatha Christie", Price = 11.99m, Description = "A psychological thriller with a haunting and twisted plot.", ImageUrl = "https://cdn.swiatksiazki.pl/media/catalog/product/7/8/7899906403778.jpg?width=650&height=650&store=default&image-type=small_image" },
                new Book { Id = 8, Title = "A Haunting in Venice", Author = "Agatha Christie", Price = 12.99m, Description = "A mystery novel involving a haunting in Venice.", ImageUrl = "https://i0.wp.com/www.hauntjaunts.net/blog/wp-content/uploads/2023/07/p_ahauntinginvenice_1890_02acdcec-e1689791481832.jpeg?fit=427%2C640&ssl=1" },
                new Book { Id = 9, Title = "Murder on the Orient Express", Author = "Agatha Christie", Price = 12.99m, Description = "Hercule Poirot's famous investigation aboard the luxurious train.", ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1733926500i/853510.jpg" }
            );
        }
    }
}
