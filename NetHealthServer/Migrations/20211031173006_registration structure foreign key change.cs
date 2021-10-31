using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class registrationstructureforeignkeychange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkoutPrograms_WorkProgramId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WorkProgramId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkProgramId",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_workout_program_id",
                table: "Users",
                column: "workout_program_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkoutPrograms_workout_program_id",
                table: "Users",
                column: "workout_program_id",
                principalTable: "WorkoutPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_WorkoutPrograms_workout_program_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_workout_program_id",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "WorkProgramId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkProgramId",
                table: "Users",
                column: "WorkProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_WorkoutPrograms_WorkProgramId",
                table: "Users",
                column: "WorkProgramId",
                principalTable: "WorkoutPrograms",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
