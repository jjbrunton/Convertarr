using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Convertarr.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaInfo",
                columns: table => new
                {
                    MediaInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaInfo", x => x.MediaInfoId);
                });

            migrationBuilder.CreateTable(
                name: "AudioStream",
                columns: table => new
                {
                    AudioStreamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Forced = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Channels = table.Column<int>(type: "INTEGER", nullable: false),
                    SampleRate = table.Column<int>(type: "INTEGER", nullable: false),
                    Bitrate = table.Column<long>(type: "INTEGER", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Default = table.Column<int>(type: "INTEGER", nullable: true),
                    MediaInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Codec = table.Column<string>(type: "TEXT", nullable: false),
                    MediaStreamType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioStream", x => x.AudioStreamId);
                    table.ForeignKey(
                        name: "FK_AudioStream_MediaInfo_MediaInfoId",
                        column: x => x.MediaInfoId,
                        principalTable: "MediaInfo",
                        principalColumn: "MediaInfoId");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    MediaFileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: false),
                    LastWrite = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MediaInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    LastScanned = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.MediaFileId);
                    table.ForeignKey(
                        name: "FK_Files_MediaInfo_MediaInfoId",
                        column: x => x.MediaInfoId,
                        principalTable: "MediaInfo",
                        principalColumn: "MediaInfoId");
                });

            migrationBuilder.CreateTable(
                name: "SubtitleStream",
                columns: table => new
                {
                    SubtitleStreamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Language = table.Column<string>(type: "TEXT", nullable: false),
                    Default = table.Column<int>(type: "INTEGER", nullable: true),
                    Forced = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    MediaInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Codec = table.Column<string>(type: "TEXT", nullable: false),
                    MediaStreamType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleStream", x => x.SubtitleStreamId);
                    table.ForeignKey(
                        name: "FK_SubtitleStream_MediaInfo_MediaInfoId",
                        column: x => x.MediaInfoId,
                        principalTable: "MediaInfo",
                        principalColumn: "MediaInfoId");
                });

            migrationBuilder.CreateTable(
                name: "VideoStream",
                columns: table => new
                {
                    VideoStreamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rotation = table.Column<int>(type: "INTEGER", nullable: true),
                    Forced = table.Column<int>(type: "INTEGER", nullable: true),
                    Default = table.Column<int>(type: "INTEGER", nullable: true),
                    Bitrate = table.Column<long>(type: "INTEGER", nullable: false),
                    Ratio = table.Column<string>(type: "TEXT", nullable: false),
                    Framerate = table.Column<double>(type: "REAL", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    PixelFormat = table.Column<string>(type: "TEXT", nullable: false),
                    MediaInfoId = table.Column<int>(type: "INTEGER", nullable: true),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Codec = table.Column<string>(type: "TEXT", nullable: false),
                    MediaStreamType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStream", x => x.VideoStreamId);
                    table.ForeignKey(
                        name: "FK_VideoStream_MediaInfo_MediaInfoId",
                        column: x => x.MediaInfoId,
                        principalTable: "MediaInfo",
                        principalColumn: "MediaInfoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioStream_MediaInfoId",
                table: "AudioStream",
                column: "MediaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_MediaInfoId",
                table: "Files",
                column: "MediaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleStream_MediaInfoId",
                table: "SubtitleStream",
                column: "MediaInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoStream_MediaInfoId",
                table: "VideoStream",
                column: "MediaInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioStream");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "SubtitleStream");

            migrationBuilder.DropTable(
                name: "VideoStream");

            migrationBuilder.DropTable(
                name: "MediaInfo");
        }
    }
}
