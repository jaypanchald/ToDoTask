using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDo.Task.Repository.Migrations
{
    public partial class ToDoTask1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "MyTask",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "MyTask",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "MyTask");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "MyTask");
        }
    }
}
