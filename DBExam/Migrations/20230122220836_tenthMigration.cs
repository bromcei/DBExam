using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class tenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_Departemnt",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "Departemnt",
                table: "HoneyProducts",
                newName: "ProductDepartmentDepartemntId");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyProducts_Departemnt",
                table: "HoneyProducts",
                newName: "IX_HoneyProducts_ProductDepartmentDepartemntId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_ProductDepartmentDepartemntId",
                table: "HoneyProducts",
                column: "ProductDepartmentDepartemntId",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_ProductDepartmentDepartemntId",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "ProductDepartmentDepartemntId",
                table: "HoneyProducts",
                newName: "Departemnt");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyProducts_ProductDepartmentDepartemntId",
                table: "HoneyProducts",
                newName: "IX_HoneyProducts_Departemnt");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_Departemnt",
                table: "HoneyProducts",
                column: "Departemnt",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
