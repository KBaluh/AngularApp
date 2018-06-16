using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBRepository.Migrations
{
    public partial class TaskStatusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskStatusModelId",
                table: "Tasks",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskStatusModel",
                columns: table => new
                {
                    TaskStatusModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatusModel", x => x.TaskStatusModelId);
                });

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatusModel_TaskStatusModelId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskStatusModel");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskStatusModelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskStatusModelId",
                table: "Tasks");
        }
    }
}
