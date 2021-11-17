using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    week_day = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calory = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Gym_program",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gym_program", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    calory = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    time_of_day = table.Column<short>(type: "smallint", nullable: false),
                    image_url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    meal_url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    action_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Meals_Action_action_id",
                        column: x => x.action_id,
                        principalTable: "Action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Nutrition_program",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    action_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutrition_program", x => x.id);
                    table.ForeignKey(
                        name: "FK_Nutrition_program_Action_action_id",
                        column: x => x.action_id,
                        principalTable: "Action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "diets_meals",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diets_meals", x => new { x.DietId, x.MealId });
                    table.ForeignKey(
                        name: "FK_diets_meals_Diet_DietId",
                        column: x => x.DietId,
                        principalTable: "Diet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diets_meals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nutrutions_diets",
                columns: table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false),
                    NutritionProgramId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutrutions_diets", x => new { x.DietId, x.NutritionProgramId });
                    table.ForeignKey(
                        name: "FK_nutrutions_diets_Diet_DietId",
                        column: x => x.DietId,
                        principalTable: "Diet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nutrutions_diets_Nutrition_program_NutritionProgramId",
                        column: x => x.NutritionProgramId,
                        principalTable: "Nutrition_program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fullname = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    age = table.Column<short>(type: "smallint", nullable: false),
                    weight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    height = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    number_of_meals = table.Column<short>(type: "smallint", nullable: false),
                    number_of_gyms = table.Column<short>(type: "smallint", nullable: false),
                    amount_of_calories = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    nutrition_program_id = table.Column<int>(type: "int", nullable: true),
                    gym_program_id = table.Column<int>(type: "int", nullable: true),
                    action_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Action_action_id",
                        column: x => x.action_id,
                        principalTable: "Action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Gym_program_gym_program_id",
                        column: x => x.gym_program_id,
                        principalTable: "Gym_program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Nutrition_program_nutrition_program_id",
                        column: x => x.nutrition_program_id,
                        principalTable: "Nutrition_program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Loose Weight" },
                    { 2, "Gain Weight" }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "id", "name", "week_day" },
                values: new object[,]
                {
                    { 2, "wednesday_gain_menu", (short)3 },
                    { 3, "wednesday_loose_menu", (short)3 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "id", "action_id", "amount", "calory", "image_url", "meal_url", "name", "time_of_day" },
                values: new object[,]
                {
                    { 7, null, "80", 267.2m, "https://images.eatthismuch.com/site_media/img/1112_erin_m_82150710-3374-4cb8-94cc-7071559fce2b.png", "https://www.eatthismuch.com/food/nutrition/oatmeal,1112/", "Oatmeal", (short)1 },
                    { 8, null, "140", 221.2m, "https://images.eatthismuch.com/site_media/img/4857_laurabedo_da2c9648-14a9-47fd-bff3-3c1d66ad3fa7.png", "https://www.eatthismuch.com/food/nutrition/macaroni,4857/", "Macaroni", (short)2 },
                    { 9, null, "168", 154.6m, "https://images.eatthismuch.com/site_media/img/4778_cyberchristie_6edef096-491d-4559-8df0-3281552ba4af.png", "https://www.eatthismuch.com/food/nutrition/buckwheat-groats,4778/", "Buckwheat groats", (short)2 },
                    { 10, null, "555", 253m, "https://images.eatthismuch.com/site_media/img/45207_tabitharwheeler_50bb20bd-abb6-4373-90d6-dece7b636b16.jpg", "https://www.eatthismuch.com/recipe/nutrition/perfect-steamed-rice,45207/", "Perfect Steamed Rice", (short)3 }
                });

            migrationBuilder.InsertData(
                table: "Nutrition_program",
                columns: new[] { "id", "action_id", "name" },
                values: new object[,]
                {
                    { 3, 1, "first_down" },
                    { 2, 2, "first_up" }
                });

            migrationBuilder.InsertData(
                table: "diets_meals",
                columns: new[] { "DietId", "MealId" },
                values: new object[,]
                {
                    { 2, 7 },
                    { 3, 7 },
                    { 2, 8 },
                    { 3, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 2, 10 },
                    { 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "nutrutions_diets",
                columns: new[] { "DietId", "NutritionProgramId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "nutrutions_diets",
                columns: new[] { "DietId", "NutritionProgramId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_diets_meals_MealId",
                table: "diets_meals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_gym_workouts_WorkoutsId",
                table: "gym_workouts",
                column: "WorkoutsId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_action_id",
                table: "Meals",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_program_action_id",
                table: "Nutrition_program",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_nutrutions_diets_NutritionProgramId",
                table: "nutrutions_diets",
                column: "NutritionProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_action_id",
                table: "Users",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_gym_program_id",
                table: "Users",
                column: "gym_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_nutrition_program_id",
                table: "Users",
                column: "nutrition_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_workouts_exercises_WorkoutsId",
                table: "workouts_exercises",
                column: "WorkoutsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "diets_meals");

            migrationBuilder.DropTable(
                name: "gym_workouts");

            migrationBuilder.DropTable(
                name: "nutrutions_diets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "workouts_exercises");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Gym_program");

            migrationBuilder.DropTable(
                name: "Nutrition_program");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Action");
        }
    }
}
