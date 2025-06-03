using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class LeaveModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Leaves",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Leaves",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Leaves",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Leaves",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Leaves",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Leaves",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Leaves",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Leaves",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Leaves",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Leaves");
        }
    }
}
