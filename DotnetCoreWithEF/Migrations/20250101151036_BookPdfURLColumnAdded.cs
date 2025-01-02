using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetCoreWithEF.Migrations
{
    /// <inheritdoc />
    public partial class BookPdfURLColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookPdfURL",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookPdfURL",
                table: "Books");
        }
    }
}
