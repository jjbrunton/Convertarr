﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Convertarr.Data.Migrations
{
    /// <inheritdoc />
    public partial class FileHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileHash",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastScanned",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileHash",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "LastScanned",
                table: "Files");
        }
    }
}
