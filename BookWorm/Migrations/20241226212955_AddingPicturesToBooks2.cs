using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm.Migrations
{
    /// <inheritdoc />
    public partial class AddingPicturesToBooks2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://i.etsystatic.com/20545894/r/il/7d8e6d/1977091569/il_570xN.1977091569_fv4f.jpg");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "");
        }
    }
}
