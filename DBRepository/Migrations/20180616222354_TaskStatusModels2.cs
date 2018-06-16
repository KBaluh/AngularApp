using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class TaskStatusModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusModel_TaskStatusModelId",
                table: "Tasks");
                
            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStatusModelId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatusModel",
                table: "TaskStatusModel");

            migrationBuilder.RenameTable(
                name: "TaskStatusModel",
                newName: "TaskStatusModels");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TaskStatusModels",
                newName: "TaskStatusModelName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatusModels",
                table: "TaskStatusModels",
                column: "TaskStatusModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskStatusModels",
                table: "TaskStatusModels");

            migrationBuilder.RenameTable(
                name: "TaskStatusModels",
                newName: "TaskStatusModel");

            migrationBuilder.RenameColumn(
                name: "TaskStatusModelName",
                table: "TaskStatusModel",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskStatusModel",
                table: "TaskStatusModel",
                column: "TaskStatusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskStatusModelId",
                table: "Tasks",
                column: "TaskStatusModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatusModel_TaskStatusModelId",
                table: "Tasks",
                column: "TaskStatusModelId",
                principalTable: "TaskStatusModel",
                principalColumn: "TaskStatusModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
