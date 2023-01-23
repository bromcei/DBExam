using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProductsSupliers_HoneyProducts_HoneyProductHoneyId",
                table: "HoneyProductsSupliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoneyProductsSupliers",
                table: "HoneyProductsSupliers");

            migrationBuilder.DropIndex(
                name: "IX_HoneyProductsSupliers_HoneyProductHoneyId",
                table: "HoneyProductsSupliers");

            migrationBuilder.DropColumn(
                name: "HoneyId",
                table: "HoneyProductsSupliers");

            migrationBuilder.RenameColumn(
                name: "HoneyProductHoneyId",
                table: "HoneyProductsSupliers",
                newName: "HoneyProductId");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "HoneyProductsSupliers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentID",
                table: "HoneyProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "DepartmentSuppliers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "DepartmentSuppliers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoneyProductsSupliers",
                table: "HoneyProductsSupliers",
                columns: new[] { "HoneyProductId", "SupplierId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProductsSupliers_HoneyProducts_HoneyProductId",
                table: "HoneyProductsSupliers",
                column: "HoneyProductId",
                principalTable: "HoneyProducts",
                principalColumn: "HoneyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProductsSupliers_HoneyProducts_HoneyProductId",
                table: "HoneyProductsSupliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoneyProductsSupliers",
                table: "HoneyProductsSupliers");

            migrationBuilder.RenameColumn(
                name: "HoneyProductId",
                table: "HoneyProductsSupliers",
                newName: "HoneyProductHoneyId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "Suppliers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "HoneyProductsSupliers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "HoneyId",
                table: "HoneyProductsSupliers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentID",
                table: "HoneyProducts",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "SupplierId",
                table: "DepartmentSuppliers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "DepartmentSuppliers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoneyProductsSupliers",
                table: "HoneyProductsSupliers",
                columns: new[] { "HoneyId", "SupplierId" });

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProductsSupliers_HoneyProductHoneyId",
                table: "HoneyProductsSupliers",
                column: "HoneyProductHoneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProductsSupliers_HoneyProducts_HoneyProductHoneyId",
                table: "HoneyProductsSupliers",
                column: "HoneyProductHoneyId",
                principalTable: "HoneyProducts",
                principalColumn: "HoneyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
