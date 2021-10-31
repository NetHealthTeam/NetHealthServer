using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class workout_table_name_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkoutPrograms_gym_program_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutPrograms",
                table: "WorkoutPrograms");

            migrationBuilder.RenameTable(
                name: "WorkoutPrograms",
                newName: "GymPrograms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymPrograms",
                table: "GymPrograms",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GymPrograms_gym_program_id",
                table: "Users",
                column: "gym_program_id",
                principalTable: "GymPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GymPrograms_gym_program_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymPrograms",
                table: "GymPrograms");

            migrationBuilder.RenameTable(
                name: "GymPrograms",
                newName: "WorkoutPrograms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutPrograms",
                table: "WorkoutPrograms",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkoutPrograms_gym_program_id",
                table: "Users",
                column: "gym_program_id",
                principalTable: "WorkoutPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
