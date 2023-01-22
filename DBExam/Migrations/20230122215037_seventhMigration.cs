using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_ProductDepartmentId",
                table: "HoneyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProductSupplier_Suppliers_SupplierListId",
                table: "HoneyProductSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Departments_DepartmentId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_HoneyProducts_ProductDepartmentId",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Suppliers",
                newName: "DepartmentDepartemntId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Suppliers",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_DepartmentId",
                table: "Suppliers",
                newName: "IX_Suppliers_DepartmentDepartemntId");

            migrationBuilder.RenameColumn(
                name: "SupplierListId",
                table: "HoneyProductSupplier",
                newName: "SupplierListSupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyProductSupplier_SupplierListId",
                table: "HoneyProductSupplier",
                newName: "IX_HoneyProductSupplier_SupplierListSupplierId");

            migrationBuilder.RenameColumn(
                name: "ProductDepartmentId",
                table: "HoneyProducts",
                newName: "HoneyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DepartemntId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_Id",
                table: "HoneyProducts",
                column: "Id",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProductSupplier_Suppliers_SupplierListSupplierId",
                table: "HoneyProductSupplier",
                column: "SupplierListSupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Departments_DepartmentDepartemntId",
                table: "Suppliers",
                column: "DepartmentDepartemntId",
                principalTable: "Departments",
                principalColumn: "DepartemntId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_Id",
                table: "HoneyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProductSupplier_Suppliers_SupplierListSupplierId",
                table: "HoneyProductSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Departments_DepartmentDepartemntId",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "DepartmentDepartemntId",
                table: "Suppliers",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_DepartmentDepartemntId",
                table: "Suppliers",
                newName: "IX_Suppliers_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "SupplierListSupplierId",
                table: "HoneyProductSupplier",
                newName: "SupplierListId");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyProductSupplier_SupplierListSupplierId",
                table: "HoneyProductSupplier",
                newName: "IX_HoneyProductSupplier_SupplierListId");

            migrationBuilder.RenameColumn(
                name: "HoneyId",
                table: "HoneyProducts",
                newName: "ProductDepartmentId");

            migrationBuilder.RenameColumn(
                name: "DepartemntId",
                table: "Departments",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProducts_ProductDepartmentId",
                table: "HoneyProducts",
                column: "ProductDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_ProductDepartmentId",
                table: "HoneyProducts",
                column: "ProductDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProductSupplier_Suppliers_SupplierListId",
                table: "HoneyProductSupplier",
                column: "SupplierListId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Departments_DepartmentId",
                table: "Suppliers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
