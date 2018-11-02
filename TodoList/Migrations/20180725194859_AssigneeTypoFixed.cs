using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations
{
    public partial class AssigneeTypoFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Asignees_AsigneeID",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Asignees");

            migrationBuilder.CreateTable(
                name: "Assignees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignees", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Assignees_AsigneeID",
                table: "Todos",
                column: "AsigneeID",
                principalTable: "Assignees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Assignees_AsigneeID",
                table: "Todos");

            migrationBuilder.DropTable(
                name: "Assignees");

            migrationBuilder.CreateTable(
                name: "Asignees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignees", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Asignees_AsigneeID",
                table: "Todos",
                column: "AsigneeID",
                principalTable: "Asignees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
