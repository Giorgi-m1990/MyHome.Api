using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHome.Infrastructure.Migrations
{
    public partial class AdStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdStatus",
                table: "Advertainments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdStatus",
                table: "Advertainments");
        }
    }
}
