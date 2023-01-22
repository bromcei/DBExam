using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSupplier");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "HoneyProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoneyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoneyProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoneyProducts_Departments_ProductDepartmentId",
                        column: x => x.ProductDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoneyProductSupplier",
                columns: table => new
                {
                    HoneyProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoneyProductSupplier", x => new { x.HoneyProductsId, x.SupplierListId });
                    table.ForeignKey(
                        name: "FK_HoneyProductSupplier_HoneyProducts_HoneyProductsId",
                        column: x => x.HoneyProductsId,
                        principalTable: "HoneyProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoneyProductSupplier_Suppliers_SupplierListId",
                        column: x => x.SupplierListId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProducts_ProductDepartmentId",
                table: "HoneyProducts",
                column: "ProductDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HoneyProductSupplier_SupplierListId",
                table: "HoneyProductSupplier",
                column: "SupplierListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoneyProductSupplier");

            migrationBuilder.DropTable(
                name: "HoneyProducts");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Departments_ProductDepartmentId",
                        column: x => x.ProductDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplier",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplier", x => new { x.ProductsId, x.SupplierListId });
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSupplier_Suppliers_SupplierListId",
                        column: x => x.SupplierListId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductDepartmentId",
                table: "Products",
                column: "ProductDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplier_SupplierListId",
                table: "ProductSupplier",
                column: "SupplierListId");
        }
    }
}
