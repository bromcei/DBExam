using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class twelvthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DepartmentID",
                table: "HoneyProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProducts_DepartmentID",
                table: "HoneyProducts",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_DepartmentID",
                table: "HoneyProducts",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_DepartmentID",
                table: "HoneyProducts");

            migrationBuilder.DropIndex(
                name: "IX_HoneyProducts_DepartmentID",
                table: "HoneyProducts");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
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
    }
}
