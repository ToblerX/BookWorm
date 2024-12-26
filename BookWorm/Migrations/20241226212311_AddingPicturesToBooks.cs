using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWorm.Migrations
{
    /// <inheritdoc />
    public partial class AddingPicturesToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Book");
        }
    }
}
