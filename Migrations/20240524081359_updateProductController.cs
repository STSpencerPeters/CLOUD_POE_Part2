using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CLOUD_POE_Part2.Migrations
{
    /// <inheritdoc />
    public partial class updateProductController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                table: "Product");
        }
    }
}
