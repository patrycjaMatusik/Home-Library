using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibAPI.Migrations
{
    public partial class publisherInLibraryElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Magazines_Publishers_PublisherId",
                table: "Magazines");

            migrationBuilder.DropForeignKey(
                name: "FK_Multimedias_Publishers_PublisherId",
                table: "Multimedias");

            migrationBuilder.DropIndex(
                name: "IX_Multimedias_PublisherId",
                table: "Multimedias");

            migrationBuilder.DropIndex(
                name: "IX_Magazines_PublisherId",
                table: "Magazines");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublisherId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Multimedias");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Magazines");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "LibraryElement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LibraryElement_PublisherId",
                table: "LibraryElement",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryElement_Publishers_PublisherId",
                table: "LibraryElement",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryElement_Publishers_PublisherId",
                table: "LibraryElement");

            migrationBuilder.DropIndex(
                name: "IX_LibraryElement_PublisherId",
                table: "LibraryElement");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "LibraryElement");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Multimedias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Magazines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Multimedias_PublisherId",
                table: "Multimedias",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Magazines_PublisherId",
                table: "Magazines",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublisherId",
                table: "Books",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magazines_Publishers_PublisherId",
                table: "Magazines",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedias_Publishers_PublisherId",
                table: "Multimedias",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
