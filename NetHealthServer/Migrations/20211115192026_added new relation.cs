using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class addednewrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionId",
                table: "Nutrition_program",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_program_ActionId",
                table: "Nutrition_program",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrition_program_Action_ActionId",
                table: "Nutrition_program",
                column: "ActionId",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrition_program_Action_ActionId",
                table: "Nutrition_program");

            migrationBuilder.DropIndex(
                name: "IX_Nutrition_program_ActionId",
                table: "Nutrition_program");

            migrationBuilder.DropColumn(
                name: "ActionId",
                table: "Nutrition_program");
        }
    }
}
