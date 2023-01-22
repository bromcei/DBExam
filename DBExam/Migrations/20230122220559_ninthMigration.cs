using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBExam.Migrations
{
    public partial class ninthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_DepartemntId",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "DepartemntId",
                table: "HoneyProducts",
                newName: "Departemnt");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyProducts_DepartemntId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyProducts_Departments_Departemnt",
                table: "HoneyProducts");

            migrationBuilder.RenameColumn(
                name: "Departemnt",
                table: "HoneyProducts",
                newName: "DepartemntId");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyProducts_Departemnt",
                table: "HoneyProducts",
                newName: "IX_HoneyProducts_DepartemntId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyProducts_Departments_DepartemntId",
                table: "HoneyProducts",
                column: "DepartemntId",
                principalTable: "Departments",
                principalColumn: "DepartemntId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
