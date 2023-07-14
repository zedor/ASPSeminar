using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Seminar.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasImage",
                table: "Product",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasImage",
                table: "Product");
        }
    }
}
