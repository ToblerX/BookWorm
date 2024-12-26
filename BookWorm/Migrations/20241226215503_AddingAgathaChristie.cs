using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWorm.Migrations
{
    /// <inheritdoc />
    public partial class AddingAgathaChristie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Author", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, "Agatha Christie", "A classic detective novel featuring Hercule Poirot.", "https://m.media-amazon.com/images/I/714wbWkDOUL._AC_UF1000,1000_QL80_.jpg", 10.99m, "Crooked House" },
                    { 5, "Agatha Christie", "One of the most famous and controversial Poirot mysteries.", "https://m.media-amazon.com/images/I/61a0Vb1bjJL._AC_UF1000,1000_QL80_.jpg", 10.99m, "Murder of Roger Ackroyd" },
                    { 6, "Agatha Christie", "A Hercule Poirot mystery involving a family secret.", "https://media.thuprai.com/__sized__/front_covers/after-the-funeral-9b55moz7-thumbnail-280x405-70.jpg", 11.99m, "After the Funeral" },
                    { 7, "Agatha Christie", "A psychological thriller with a haunting and twisted plot.", "https://cdn.swiatksiazki.pl/media/catalog/product/7/8/7899906403778.jpg?width=650&height=650&store=default&image-type=small_image", 11.99m, "Endless Night" },
                    { 8, "Agatha Christie", "A mystery novel involving a haunting in Venice.", "https://i0.wp.com/www.hauntjaunts.net/blog/wp-content/uploads/2023/07/p_ahauntinginvenice_1890_02acdcec-e1689791481832.jpeg?fit=427%2C640&ssl=1", 12.99m, "A Haunting in Venice" },
                    { 9, "Agatha Christie", "Hercule Poirot's famous investigation aboard the luxurious train.", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1733926500i/853510.jpg", 12.99m, "Murder on the Orient Express" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
