using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class LeaveBalanceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveBalances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EmployeeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PreviousBalance = table.Column<int>(type: "int", nullable: false),
                    CurrentBalance = table.Column<int>(type: "int", nullable: false),
                    TotalBalance = table.Column<int>(type: "int", nullable: false),
                    UsedLeave = table.Column<int>(type: "int", nullable: false),
                    AcceptedLeave = table.Column<int>(type: "int", nullable: false),
                    RejectedLeave = table.Column<int>(type: "int", nullable: false),
                    ExpiredLeave = table.Column<int>(type: "int", nullable: false),
                    CarryOverBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveBalances_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "ClaimValue",
                value: "LeaveBalance.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "ClaimValue",
                value: "LeaveBalance.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "ClaimValue",
                value: "LeaveUpdate.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "ClaimValue",
                value: "LeaveBalance.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "ClaimValue",
                value: "SalaryStructure.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "ClaimValue",
                value: "SalaryStructure.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "ClaimValue",
                value: "SalaryStructure.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "ClaimValue",
                value: "SalaryStructure.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "ClaimValue",
                value: "Payroll.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "ClaimValue",
                value: "Payroll.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "ClaimValue",
                value: "Payroll.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "ClaimValue",
                value: "Payroll.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "ClaimValue",
                value: "Project.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "ClaimValue",
                value: "Project.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "ClaimValue",
                value: "Project.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "ClaimValue",
                value: "Project.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "EmployeeProject.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "EmployeeProject.Assign", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "EmployeeProject.Unassign", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "EmployeeProject.UpdateRole", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "ClaimValue",
                value: "Employee.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "ClaimValue",
                value: "Employee.Attendance.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "ClaimValue",
                value: "Employee.Attendance.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "ClaimValue",
                value: "Employee.Attendance.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "ClaimValue",
                value: "Employee.Certificate.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "ClaimValue",
                value: "Employee.Education.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "ClaimValue",
                value: "Employee.WorkExperience.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "ClaimValue",
                value: "Employee.ContactDetails.View");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 81, "Permission", "Employee.FamilyDetail.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 82, "Permission", "Leave.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 83, "Permission", "LeaveBalance.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 84, "Permission", "Payroll.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 85, "Permission", "Asset.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveBalances_EmployeeId",
                table: "LeaveBalances",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveBalances");

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 53,
                column: "ClaimValue",
                value: "SalaryStructure.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 54,
                column: "ClaimValue",
                value: "SalaryStructure.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 55,
                column: "ClaimValue",
                value: "SalaryStructure.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 56,
                column: "ClaimValue",
                value: "SalaryStructure.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 57,
                column: "ClaimValue",
                value: "Payroll.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 58,
                column: "ClaimValue",
                value: "Payroll.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 59,
                column: "ClaimValue",
                value: "Payroll.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 60,
                column: "ClaimValue",
                value: "Payroll.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 61,
                column: "ClaimValue",
                value: "Project.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 62,
                column: "ClaimValue",
                value: "Project.Create");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 63,
                column: "ClaimValue",
                value: "Project.Update");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 64,
                column: "ClaimValue",
                value: "Project.Delete");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 65,
                column: "ClaimValue",
                value: "EmployeeProject.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 66,
                column: "ClaimValue",
                value: "EmployeeProject.Assign");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 67,
                column: "ClaimValue",
                value: "EmployeeProject.Unassign");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 68,
                column: "ClaimValue",
                value: "EmployeeProject.UpdateRole");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Employee.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Employee.Attendance.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Employee.Attendance.Create", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "Employee.Attendance.Update", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 73,
                column: "ClaimValue",
                value: "Employee.Certificate.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 74,
                column: "ClaimValue",
                value: "Employee.Education.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 75,
                column: "ClaimValue",
                value: "Employee.WorkExperience.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 76,
                column: "ClaimValue",
                value: "Employee.ContactDetails.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 77,
                column: "ClaimValue",
                value: "Employee.FamilyDetail.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 78,
                column: "ClaimValue",
                value: "Leave.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 79,
                column: "ClaimValue",
                value: "Payroll.View");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 80,
                column: "ClaimValue",
                value: "Asset.View");
        }
    }
}
