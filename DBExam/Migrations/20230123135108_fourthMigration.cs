using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class fourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSupplier_Departments_DepartmentId",
                table: "DepartmentSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSupplier_Suppliers_SupplierId",
                table: "DepartmentSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentSupplier",
                table: "DepartmentSupplier");

            migrationBuilder.RenameTable(
                name: "DepartmentSupplier",
                newName: "DepartmentSuppliers");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentSupplier_SupplierId",
                table: "DepartmentSuppliers",
                newName: "IX_DepartmentSuppliers_SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentSuppliers",
                table: "DepartmentSuppliers",
                columns: new[] { "DepartmentId", "SupplierId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSuppliers_Departments_DepartmentId",
                table: "DepartmentSuppliers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSuppliers_Suppliers_SupplierId",
                table: "DepartmentSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSuppliers_Departments_DepartmentId",
                table: "DepartmentSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSuppliers_Suppliers_SupplierId",
                table: "DepartmentSuppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentSuppliers",
                table: "DepartmentSuppliers");

            migrationBuilder.RenameTable(
                name: "DepartmentSuppliers",
                newName: "DepartmentSupplier");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentSuppliers_SupplierId",
                table: "DepartmentSupplier",
                newName: "IX_DepartmentSupplier_SupplierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentSupplier",
                table: "DepartmentSupplier",
                columns: new[] { "DepartmentId", "SupplierId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSupplier_Departments_DepartmentId",
                table: "DepartmentSupplier",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSupplier_Suppliers_SupplierId",
                table: "DepartmentSupplier",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
