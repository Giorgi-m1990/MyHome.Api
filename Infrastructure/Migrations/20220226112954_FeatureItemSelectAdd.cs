using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHome.Infrastructure.Migrations
{
    public partial class FeatureItemSelectAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeatureItemSelectId",
                table: "AdvertainmentFeatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeatureItemSelects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureItemSelects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureItemSelects_FeatureItems_FeatureItemId",
                        column: x => x.FeatureItemId,
                        principalTable: "FeatureItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureItemSelects_FeatureItemId",
                table: "FeatureItemSelects",
                column: "FeatureItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureItemSelects");

            migrationBuilder.DropColumn(
                name: "FeatureItemSelectId",
                table: "AdvertainmentFeatures");
        }
    }
}
