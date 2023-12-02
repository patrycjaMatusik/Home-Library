using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeLibAPI.Migrations
{
    public partial class deleteRecordLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Multimedias_RecordLabels_RecordLabelId",
                table: "Multimedias");

            migrationBuilder.RenameColumn(
                name: "RecordLabelId",
                table: "Multimedias",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Multimedias_RecordLabelId",
                table: "Multimedias",
                newName: "IX_Multimedias_PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedias_Publishers_PublisherId",
                table: "Multimedias",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Multimedias_Publishers_PublisherId",
                table: "Multimedias");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                table: "Multimedias",
                newName: "RecordLabelId");

            migrationBuilder.RenameIndex(
                name: "IX_Multimedias_PublisherId",
                table: "Multimedias",
                newName: "IX_Multimedias_RecordLabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedias_RecordLabels_RecordLabelId",
                table: "Multimedias",
                column: "RecordLabelId",
                principalTable: "RecordLabels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
