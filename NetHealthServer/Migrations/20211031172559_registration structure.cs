using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class registrationstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NutritionPrograms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionPrograms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutPrograms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutPrograms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<short>(type: "smallint", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    number_of_meals = table.Column<short>(type: "smallint", nullable: false),
                    amount_of_calories = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    nutrition_program_id = table.Column<int>(type: "int", nullable: false),
                    workout_program_id = table.Column<int>(type: "int", nullable: false),
                    WorkProgramId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_NutritionPrograms_nutrition_program_id",
                        column: x => x.nutrition_program_id,
                        principalTable: "NutritionPrograms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_WorkoutPrograms_WorkProgramId",
                        column: x => x.WorkProgramId,
                        principalTable: "WorkoutPrograms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_nutrition_program_id",
                table: "Users",
                column: "nutrition_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkProgramId",
                table: "Users",
                column: "WorkProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "NutritionPrograms");

            migrationBuilder.DropTable(
                name: "WorkoutPrograms");
        }
    }
}
