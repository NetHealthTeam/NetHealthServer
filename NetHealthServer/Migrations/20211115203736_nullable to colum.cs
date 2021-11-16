using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class nullabletocolum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Action_action_id",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "action_id",
                table: "Meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "amount",
                table: "Meals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Action_action_id",
                table: "Meals",
                column: "action_id",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Action_action_id",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Meals");

            migrationBuilder.AlterColumn<int>(
                name: "action_id",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Action_action_id",
                table: "Meals",
                column: "action_id",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
