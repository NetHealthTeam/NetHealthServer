using Microsoft.EntityFrameworkCore.Migrations;

namespace NetHealthServer.Migrations
{
    public partial class seeddatatoexercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calory",
                table: "Exercise");

            migrationBuilder.AddColumn<decimal>(
                name: "minute_per_exercise",
                table: "Workouts",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "week_day",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "calory_per_hour",
                table: "Exercise",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "Exercise",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Exercise",
                columns: new[] { "id", "calory_per_hour", "image_url", "name" },
                values: new object[,]
                {
                    { 1, "667-990", "https://static.toiimg.com/photo/71956822.cms", "Jumping Rope" },
                    { 2, "566-839", "https://post.healthline.com/wp-content/uploads/2020/01/Runner-training-on-running-track-732x549-thumbnail.jpg", "Running" },
                    { 3, "568-841", "https://cdn.mos.cms.futurecdn.net/M825uvxzJE2MDmqSfFb7PY.jpg", "Cycling" },
                    { 4, "452-670", "https://www.muscleandfitness.com/wp-content/uploads/2019/06/man-running-stairs-1109.jpg?w=940&h=529&crop=1&quality=86&strip=all", "Stairs" },
                    { 5, "639-946", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/766/runninguphill-1501799541.jpg", "Running Up Hills" },
                    { 6, "226-335", "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/766/runninguphill-1501799541.jpg", "Running Up Hills" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercise",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "minute_per_exercise",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "week_day",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "calory_per_hour",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "Exercise");

            migrationBuilder.AddColumn<decimal>(
                name: "calory",
                table: "Exercise",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
