using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Convertarr.Data.Migrations
{
    /// <inheritdoc />
    public partial class MediaAnalysis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "MediaInfoId");

            migrationBuilder.AlterColumn<int>(
                name: "MediaInfoId",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "MediaFileId",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "MediaFileId");

            migrationBuilder.CreateTable(
                name: "MediaInfo",
                columns: table => new
                {
                    MediaInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInfo", x => x.MediaInfoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_MediaInfoId",
                table: "Files",
                column: "MediaInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_MediaInfo_MediaInfoId",
                table: "Files",
                column: "MediaInfoId",
                principalTable: "MediaInfo",
                principalColumn: "MediaInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_MediaInfo_MediaInfoId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "MediaInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_MediaInfoId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "MediaFileId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "MediaInfoId",
                table: "Files",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                column: "Id");
        }
    }
}
