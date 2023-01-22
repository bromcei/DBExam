using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DepartmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDepartmentId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDepartmentId",
                table: "Products",
                column: "ProductDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_ProductDepartmentId",
                table: "Products",
                column: "ProductDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_ProductDepartmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductDepartmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDepartmentId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DepartmentId",
                table: "Products",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_DepartmentId",
                table: "Products",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
