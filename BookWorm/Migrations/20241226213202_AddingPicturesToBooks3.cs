using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm.Migrations
{
    /// <inheritdoc />
    public partial class AddingPicturesToBooks3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61ZewDE3beL.jpg");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://cdn.britannica.com/21/182021-050-666DB6B1/book-cover-To-Kill-a-Mockingbird-many-1961.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://i.etsystatic.com/20545894/r/il/7d8e6d/1977091569/il_570xN.1977091569_fv4f.jpg");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.etsystatic.com/20545894/r/il/7d8e6d/1977091569/il_570xN.1977091569_fv4f.jpg");
        }
    }
}
