using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class nutrition_dietmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekDay = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nutritions_diets",
                columns: table => new
                {
                    DietsId = table.Column<int>(type: "int", nullable: false),
                    NutritionProgramsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritions_diets", x => new { x.DietsId, x.NutritionProgramsId });
                    table.ForeignKey(
                        name: "FK_nutritions_diets_Diets_DietsId",
                        column: x => x.DietsId,
                        principalTable: "Diets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nutritions_diets_NutritionPrograms_NutritionProgramsId",
                        column: x => x.NutritionProgramsId,
                        principalTable: "NutritionPrograms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nutritions_diets_NutritionProgramsId",
                table: "nutritions_diets",
                column: "NutritionProgramsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutritions_diets");

            migrationBuilder.DropTable(
                name: "Diets");
        }
    }
}
