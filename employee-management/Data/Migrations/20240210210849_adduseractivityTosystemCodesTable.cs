using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employee_management.Data.Migrations
{
    /// <inheritdoc />
    public partial class adduseractivityTosystemCodesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "systemCodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "systemCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModfiedById",
                table: "systemCodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "systemCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "systemCodes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "systemCodes");

            migrationBuilder.DropColumn(
                name: "ModfiedById",
                table: "systemCodes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "systemCodes");
        }
    }
}
