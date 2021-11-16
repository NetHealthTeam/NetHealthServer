using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class Seeddataadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diets_meals_Diet_DietsId",
                table: "diets_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_diets_meals_Meals_MealsId",
                table: "diets_meals");

            migrationBuilder.DropTable(
                name: "nutritions_diets");

            migrationBuilder.RenameColumn(
                name: "MealsId",
                table: "diets_meals",
                newName: "MealId");

            migrationBuilder.RenameColumn(
                name: "DietsId",
                table: "diets_meals",
                newName: "DietId");

            migrationBuilder.RenameIndex(
                name: "IX_diets_meals_MealsId",
                table: "diets_meals",
                newName: "IX_diets_meals_MealId");

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

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "id", "name", "week_day" },
                values: new object[] { 2, "monday_first_menu", (short)2 });

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
                values: new object[] { 2, 1, "first_up" });

            migrationBuilder.InsertData(
                table: "diets_meals",
                columns: new[] { "DietId", "MealId" },
                values: new object[,]
                {
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "nutrutions_diets",
                columns: new[] { "DietId", "NutritionProgramId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_nutrutions_diets_NutritionProgramId",
                table: "nutrutions_diets",
                column: "NutritionProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_diets_meals_Diet_DietId",
                table: "diets_meals",
                column: "DietId",
                principalTable: "Diet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_diets_meals_Meals_MealId",
                table: "diets_meals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_diets_meals_Diet_DietId",
                table: "diets_meals");

            migrationBuilder.DropForeignKey(
                name: "FK_diets_meals_Meals_MealId",
                table: "diets_meals");

            migrationBuilder.DropTable(
                name: "nutrutions_diets");

            migrationBuilder.DeleteData(
                table: "diets_meals",
                keyColumns: new[] { "DietId", "MealId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "diets_meals",
                keyColumns: new[] { "DietId", "MealId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "diets_meals",
                keyColumns: new[] { "DietId", "MealId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "diets_meals",
                keyColumns: new[] { "DietId", "MealId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "Diet",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Nutrition_program",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "MealId",
                table: "diets_meals",
                newName: "MealsId");

            migrationBuilder.RenameColumn(
                name: "DietId",
                table: "diets_meals",
                newName: "DietsId");

            migrationBuilder.RenameIndex(
                name: "IX_diets_meals_MealId",
                table: "diets_meals",
                newName: "IX_diets_meals_MealsId");

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
                        name: "FK_nutritions_diets_Diet_DietsId",
                        column: x => x.DietsId,
                        principalTable: "Diet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nutritions_diets_Nutrition_program_NutritionProgramsId",
                        column: x => x.NutritionProgramsId,
                        principalTable: "Nutrition_program",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_nutritions_diets_NutritionProgramsId",
                table: "nutritions_diets",
                column: "NutritionProgramsId");

            migrationBuilder.AddForeignKey(
                name: "FK_diets_meals_Diet_DietsId",
                table: "diets_meals",
                column: "DietsId",
                principalTable: "Diet",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_diets_meals_Meals_MealsId",
                table: "diets_meals",
                column: "MealsId",
                principalTable: "Meals",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
