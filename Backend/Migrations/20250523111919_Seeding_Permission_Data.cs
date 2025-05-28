using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Permission_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "Employee.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 2, "Permission", "Employee.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 3, "Permission", "Employee.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 4, "Permission", "Employee.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 5, "Permission", "Employee.Attendance.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 6, "Permission", "Employee.Attendance.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 7, "Permission", "Employee.Attendance.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 8, "Permission", "Employee.Attendance.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 9, "Permission", "Employee.Certificate.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 10, "Permission", "Employee.Certificate.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 11, "Permission", "Employee.Certificate.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 12, "Permission", "Employee.Certificate.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 13, "Permission", "Employee.Education.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 14, "Permission", "Employee.Education.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 15, "Permission", "Employee.Education.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 16, "Permission", "Employee.Education.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 17, "Permission", "Employee.WorkExperience.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 18, "Permission", "Employee.WorkExperience.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 19, "Permission", "Employee.WorkExperience.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 20, "Permission", "Employee.WorkExperience.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 21, "Permission", "Employee.ContactDetails.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 22, "Permission", "Employee.ContactDetails.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 23, "Permission", "Employee.ContactDetails.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 24, "Permission", "Employee.ContactDetails.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 25, "Permission", "Employee.FamilyDetail.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 26, "Permission", "Employee.FamilyDetail.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 27, "Permission", "Employee.FamilyDetail.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 28, "Permission", "Employee.FamilyDetail.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 29, "Permission", "Department.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 30, "Permission", "Department.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 31, "Permission", "Department.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 32, "Permission", "Department.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 33, "Permission", "JobRole.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 34, "Permission", "JobRole.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 35, "Permission", "JobRole.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 36, "Permission", "JobRole.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 37, "Permission", "Asset.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 38, "Permission", "Asset.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 39, "Permission", "Asset.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 40, "Permission", "Asset.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 41, "Permission", "AssetType.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 42, "Permission", "AssetType.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 43, "Permission", "AssetType.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 44, "Permission", "AssetType.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 45, "Permission", "LeaveType.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 46, "Permission", "LeaveType.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 47, "Permission", "LeaveType.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 48, "Permission", "LeaveType.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 49, "Permission", "Leave.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 50, "Permission", "Leave.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 51, "Permission", "Leave.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 52, "Permission", "Leave.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 53, "Permission", "SalaryStructure.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 54, "Permission", "SalaryStructure.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 55, "Permission", "SalaryStructure.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 56, "Permission", "SalaryStructure.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 57, "Permission", "Payroll.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 58, "Permission", "Payroll.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 59, "Permission", "Payroll.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 60, "Permission", "Payroll.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 61, "Permission", "Project.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 62, "Permission", "Project.Create", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 63, "Permission", "Project.Update", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 64, "Permission", "Project.Delete", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 65, "Permission", "EmployeeProject.View", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 66, "Permission", "EmployeeProject.Assign", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 67, "Permission", "EmployeeProject.Unassign", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 68, "Permission", "EmployeeProject.UpdateRole", "1d8c4ef2-7b23-4b92-a7e2-178bfe7ecf63" },
                    { 69, "Permission", "Employee.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 70, "Permission", "Employee.Attendance.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 71, "Permission", "Employee.Attendance.Create", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 72, "Permission", "Employee.Attendance.Update", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 73, "Permission", "Employee.Certificate.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 74, "Permission", "Employee.Education.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 75, "Permission", "Employee.WorkExperience.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 76, "Permission", "Employee.ContactDetails.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 77, "Permission", "Employee.FamilyDetail.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 78, "Permission", "Leave.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 79, "Permission", "Payroll.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" },
                    { 80, "Permission", "Asset.View", "7f99b3c4-6cf1-44b7-b62b-e7411b52a89d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 80);
        }
    }
}
