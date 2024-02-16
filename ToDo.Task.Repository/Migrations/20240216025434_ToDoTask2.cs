using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Task.Repository.Migrations
{
    public partial class ToDoTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "MyTask");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MyTask",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MyTask");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "MyTask",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }
    }
}
