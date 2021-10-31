using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class workout_name_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkoutPrograms_workout_program_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "workout_program_id",
                table: "Users",
                newName: "gym_program_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_workout_program_id",
                table: "Users",
                newName: "IX_Users_gym_program_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkoutPrograms_gym_program_id",
                table: "Users",
                column: "gym_program_id",
                principalTable: "WorkoutPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkoutPrograms_gym_program_id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "gym_program_id",
                table: "Users",
                newName: "workout_program_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_gym_program_id",
                table: "Users",
                newName: "IX_Users_workout_program_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkoutPrograms_workout_program_id",
                table: "Users",
                column: "workout_program_id",
                principalTable: "WorkoutPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
