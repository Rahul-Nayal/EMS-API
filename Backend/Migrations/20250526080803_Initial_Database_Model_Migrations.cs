using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Database_Model_Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SalaryStructures_SalaryStructureId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SalaryStructureId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SalaryStructureId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SalaryStructureId",
                table: "Employees",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SalaryStructureId",
                table: "Employees",
                column: "SalaryStructureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SalaryStructures_SalaryStructureId",
                table: "Employees",
                column: "SalaryStructureId",
                principalTable: "SalaryStructures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
