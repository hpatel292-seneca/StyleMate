using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StyleMate.Migrations
{
    /// <inheritdoc />
    public partial class addClothingCombination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingCombination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Top = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bottom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shoe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingCombination", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClothingCombination");
        }
    }
}
