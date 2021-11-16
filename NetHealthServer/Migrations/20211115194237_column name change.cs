using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class columnnamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrition_program_Action_ActionId",
                table: "Nutrition_program");

            migrationBuilder.RenameColumn(
                name: "ActionId",
                table: "Nutrition_program",
                newName: "action_id");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrition_program_ActionId",
                table: "Nutrition_program",
                newName: "IX_Nutrition_program_action_id");

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "Meals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "meal_url",
                table: "Meals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrition_program_Action_action_id",
                table: "Nutrition_program",
                column: "action_id",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrition_program_Action_action_id",
                table: "Nutrition_program");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "meal_url",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "action_id",
                table: "Nutrition_program",
                newName: "ActionId");

            migrationBuilder.RenameIndex(
                name: "IX_Nutrition_program_action_id",
                table: "Nutrition_program",
                newName: "IX_Nutrition_program_ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrition_program_Action_ActionId",
                table: "Nutrition_program",
                column: "ActionId",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
