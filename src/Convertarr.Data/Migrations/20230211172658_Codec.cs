using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Convertarr.Data.Migrations
{
    /// <inheritdoc />
    public partial class Codec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codec",
                table: "MediaInfo",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codec",
                table: "MediaInfo");
        }
    }
}
