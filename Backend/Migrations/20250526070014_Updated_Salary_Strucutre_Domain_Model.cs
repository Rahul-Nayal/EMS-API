using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Salary_Strucutre_Domain_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SalaryStructures",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SalaryStructures",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SalaryStructures",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "SalaryStructures",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SalaryStructures",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SalaryStructures",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "SalaryStructures",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SalaryStructures");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SalaryStructures");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SalaryStructures");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "SalaryStructures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SalaryStructures");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SalaryStructures");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "SalaryStructures");
        }
    }
}
