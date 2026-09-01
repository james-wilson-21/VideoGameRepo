using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoGameRepo.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Games",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "Other");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Games");
        }
    }
}
