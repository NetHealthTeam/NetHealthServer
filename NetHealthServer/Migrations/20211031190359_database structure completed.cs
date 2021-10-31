using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class databasestructurecompleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diets_meals_Diets_DietsId",
                table: "diets_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_nutritions_diets_Diets_DietsId",
                table: "nutritions_diets");

            migrationBuilder.DropForeignKey(
                name: "FK_nutritions_diets_NutritionPrograms_NutritionProgramsId",
                table: "nutritions_diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_GymPrograms_gym_program_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_NutritionPrograms_nutrition_program_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NutritionPrograms",
                table: "NutritionPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymPrograms",
                table: "GymPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diets",
                table: "Diets");

            migrationBuilder.RenameTable(
                name: "NutritionPrograms",
                newName: "Nutrition_program");

            migrationBuilder.RenameTable(
                name: "GymPrograms",
                newName: "Gym_program");

            migrationBuilder.RenameTable(
                name: "Diets",
                newName: "Diet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nutrition_program",
                table: "Nutrition_program",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gym_program",
                table: "Gym_program",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet",
                table: "Diet",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    calory = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gym_workouts",
                columns: table => new
                {
                    GymProgramsId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gym_workouts", x => new { x.GymProgramsId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_gym_workouts_Gym_program_GymProgramsId",
                        column: x => x.GymProgramsId,
                        principalTable: "Gym_program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gym_workouts_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workouts_exercises",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    WorkoutsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workouts_exercises", x => new { x.ExercisesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_workouts_exercises_Exercise_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercise",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_workouts_exercises_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gym_workouts_WorkoutsId",
                table: "gym_workouts",
                column: "WorkoutsId");

            migrationBuilder.CreateIndex(
                name: "IX_workouts_exercises_WorkoutsId",
                table: "workouts_exercises",
                column: "WorkoutsId");

            migrationBuilder.AddForeignKey(
                name: "FK_diets_meals_Diet_DietsId",
                table: "diets_meals",
                column: "DietsId",
                principalTable: "Diet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nutritions_diets_Diet_DietsId",
                table: "nutritions_diets",
                column: "DietsId",
                principalTable: "Diet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nutritions_diets_Nutrition_program_NutritionProgramsId",
                table: "nutritions_diets",
                column: "NutritionProgramsId",
                principalTable: "Nutrition_program",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gym_program_gym_program_id",
                table: "Users",
                column: "gym_program_id",
                principalTable: "Gym_program",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Nutrition_program_nutrition_program_id",
                table: "Users",
                column: "nutrition_program_id",
                principalTable: "Nutrition_program",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diets_meals_Diet_DietsId",
                table: "diets_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_nutritions_diets_Diet_DietsId",
                table: "nutritions_diets");

            migrationBuilder.DropForeignKey(
                name: "FK_nutritions_diets_Nutrition_program_NutritionProgramsId",
                table: "nutritions_diets");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gym_program_gym_program_id",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nutrition_program_nutrition_program_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "gym_workouts");

            migrationBuilder.DropTable(
                name: "workouts_exercises");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nutrition_program",
                table: "Nutrition_program");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gym_program",
                table: "Gym_program");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet",
                table: "Diet");

            migrationBuilder.RenameTable(
                name: "Nutrition_program",
                newName: "NutritionPrograms");

            migrationBuilder.RenameTable(
                name: "Gym_program",
                newName: "GymPrograms");

            migrationBuilder.RenameTable(
                name: "Diet",
                newName: "Diets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NutritionPrograms",
                table: "NutritionPrograms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymPrograms",
                table: "GymPrograms",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diets",
                table: "Diets",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_diets_meals_Diets_DietsId",
                table: "diets_meals",
                column: "DietsId",
                principalTable: "Diets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nutritions_diets_Diets_DietsId",
                table: "nutritions_diets",
                column: "DietsId",
                principalTable: "Diets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_nutritions_diets_NutritionPrograms_NutritionProgramsId",
                table: "nutritions_diets",
                column: "NutritionProgramsId",
                principalTable: "NutritionPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GymPrograms_gym_program_id",
                table: "Users",
                column: "gym_program_id",
                principalTable: "GymPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_NutritionPrograms_nutrition_program_id",
                table: "Users",
                column: "nutrition_program_id",
                principalTable: "NutritionPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
