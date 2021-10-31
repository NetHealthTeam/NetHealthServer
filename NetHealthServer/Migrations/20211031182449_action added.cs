using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class actionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Diets",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Diets",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WeekDay",
                table: "Diets",
                newName: "week_day");

            migrationBuilder.AddColumn<int>(
                name: "action_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    calory = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    time_of_day = table.Column<short>(type: "smallint", nullable: false),
                    action_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.id);
                    table.ForeignKey(
                        name: "FK_Meals_Action_action_id",
                        column: x => x.action_id,
                        principalTable: "Action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diets_meals",
                columns: table => new
                {
                    DietsId = table.Column<int>(type: "int", nullable: false),
                    MealsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diets_meals", x => new { x.DietsId, x.MealsId });
                    table.ForeignKey(
                        name: "FK_diets_meals_Diets_DietsId",
                        column: x => x.DietsId,
                        principalTable: "Diets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diets_meals_Meals_MealsId",
                        column: x => x.MealsId,
                        principalTable: "Meals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_action_id",
                table: "Users",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_diets_meals_MealsId",
                table: "diets_meals",
                column: "MealsId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_action_id",
                table: "Meals",
                column: "action_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Action_action_id",
                table: "Users",
                column: "action_id",
                principalTable: "Action",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Action_action_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "diets_meals");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropIndex(
                name: "IX_Users_action_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "action_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Diets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Diets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "week_day",
                table: "Diets",
                newName: "WeekDay");
        }
    }
}
