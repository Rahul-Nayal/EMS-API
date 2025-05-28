using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Image_Model_Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_Image_AssetImageUrl",
                table: "AssetTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Image_ProfileImageUrl",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Image_ProjectImageUrl",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_Images_AssetImageUrl",
                table: "AssetTypes",
                column: "AssetImageUrl",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Images_ProfileImageUrl",
                table: "Employees",
                column: "ProfileImageUrl",
                principalTable: "Images",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Images_ProjectImageUrl",
                table: "Projects",
                column: "ProjectImageUrl",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetTypes_Images_AssetImageUrl",
                table: "AssetTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Images_ProfileImageUrl",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Images_ProjectImageUrl",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetTypes_Image_AssetImageUrl",
                table: "AssetTypes",
                column: "AssetImageUrl",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Image_ProfileImageUrl",
                table: "Employees",
                column: "ProfileImageUrl",
                principalTable: "Image",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Image_ProjectImageUrl",
                table: "Projects",
                column: "ProjectImageUrl",
                principalTable: "Image",
                principalColumn: "Id");
        }
    }
}
