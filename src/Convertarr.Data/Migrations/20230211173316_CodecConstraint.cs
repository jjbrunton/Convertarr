using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Convertarr.Data.Migrations
{
    /// <inheritdoc />
    public partial class CodecConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_MediaInfo_MediaInfoId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "MediaInfoId",
                table: "Files",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_MediaInfo_MediaInfoId",
                table: "Files",
                column: "MediaInfoId",
                principalTable: "MediaInfo",
                principalColumn: "MediaInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_MediaInfo_MediaInfoId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "MediaInfoId",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_MediaInfo_MediaInfoId",
                table: "Files",
                column: "MediaInfoId",
                principalTable: "MediaInfo",
                principalColumn: "MediaInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
