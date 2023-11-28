using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibAPI.Migrations
{
    public partial class UpdateColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "recordsList",
                table: "Multimedias",
                newName: "RecordsList");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "LibraryElement",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "LibraryElement",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecordsList",
                table: "Multimedias",
                newName: "recordsList");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "LibraryElement",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "LibraryElement",
                newName: "description");
        }
    }
}
