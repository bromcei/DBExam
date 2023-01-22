using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class eighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_Id",
                table: "HoneyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProductSupplier_HoneyProducts_HoneyProductsId",
                table: "HoneyProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoneyProducts",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "HoneyProductsId",
                table: "HoneyProductSupplier",
                newName: "HoneyProductsHoneyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "HoneyProducts",
                newName: "DepartemntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoneyProducts",
                table: "HoneyProducts",
                column: "HoneyId");

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProducts_DepartemntId",
                table: "HoneyProducts",
                column: "DepartemntId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_DepartemntId",
                table: "HoneyProducts",
                column: "DepartemntId",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProductSupplier_HoneyProducts_HoneyProductsHoneyId",
                table: "HoneyProductSupplier",
                column: "HoneyProductsHoneyId",
                principalTable: "HoneyProducts",
                principalColumn: "HoneyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_DepartemntId",
                table: "HoneyProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProductSupplier_HoneyProducts_HoneyProductsHoneyId",
                table: "HoneyProductSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoneyProducts",
                table: "HoneyProducts");

            migrationBuilder.DropIndex(
                name: "IX_HoneyProducts_DepartemntId",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "HoneyProductsHoneyId",
                table: "HoneyProductSupplier",
                newName: "HoneyProductsId");

            migrationBuilder.RenameColumn(
                name: "DepartemntId",
                table: "HoneyProducts",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoneyProducts",
                table: "HoneyProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_Id",
                table: "HoneyProducts",
                column: "Id",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProductSupplier_HoneyProducts_HoneyProductsId",
                table: "HoneyProductSupplier",
                column: "HoneyProductsId",
                principalTable: "HoneyProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
