using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class eleventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_ProductDepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.DropIndex(
                name: "IX_HoneyProducts_ProductDepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.DropColumn(
                name: "ProductDepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentDepartemntId",
                table: "HoneyProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProducts_DepartmentDepartemntId",
                table: "HoneyProducts",
                column: "DepartmentDepartemntId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_DepartmentDepartemntId",
                table: "HoneyProducts",
                column: "DepartmentDepartemntId",
                principalTable: "Departments",
                principalColumn: "DepartemntId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_DepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.DropIndex(
                name: "IX_HoneyProducts_DepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.DropColumn(
                name: "DepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductDepartmentDepartemntId",
                table: "HoneyProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProducts_ProductDepartmentDepartemntId",
                table: "HoneyProducts",
                column: "ProductDepartmentDepartemntId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_ProductDepartmentDepartemntId",
                table: "HoneyProducts",
                column: "ProductDepartmentDepartemntId",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
