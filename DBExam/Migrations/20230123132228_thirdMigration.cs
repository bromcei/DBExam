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
                name: "FK_Suppliers_Departments_DepartmentID",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_DepartmentID",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Suppliers");

            migrationBuilder.CreateTable(
                name: "DepartmentSupplier",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentSupplier", x => new { x.DepartmentId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_DepartmentSupplier_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentSupplier_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSupplier_SupplierId",
                table: "DepartmentSupplier",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentSupplier");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentID",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_DepartmentID",
                table: "Suppliers",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Departments_DepartmentID",
                table: "Suppliers",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
