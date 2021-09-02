using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorCounter.Server.Migrations
{
    public partial class nome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Nome",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Nome",
                newName: "Nome");
        }
    }
}
