using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class AssigneeModelCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AsigneeID",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "AsigneeID",
                table: "Todos",
                newName: "AssigneeID");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_AsigneeID",
                table: "Todos",
                newName: "IX_Todos_AssigneeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AssigneeID",
                table: "Todos",
                column: "AssigneeID",
                principalTable: "Assignees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AssigneeID",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "AssigneeID",
                table: "Todos",
                newName: "AsigneeID");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_AssigneeID",
                table: "Todos",
                newName: "IX_Todos_AsigneeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AsigneeID",
                table: "Todos",
                column: "AsigneeID",
                principalTable: "Assignees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
