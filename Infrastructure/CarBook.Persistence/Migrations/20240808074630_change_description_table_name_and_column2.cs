using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class change_description_table_name_and_column2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Cars_CarId",
                table: "Descriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions");

            migrationBuilder.RenameTable(
                name: "Descriptions",
                newName: "CarDescriptions");

            migrationBuilder.RenameIndex(
                name: "IX_Descriptions_CarId",
                table: "CarDescriptions",
                newName: "IX_CarDescriptions_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDescriptions",
                table: "CarDescriptions",
                column: "CarDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDescriptions_Cars_CarId",
                table: "CarDescriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDescriptions",
                table: "CarDescriptions");

            migrationBuilder.RenameTable(
                name: "CarDescriptions",
                newName: "Descriptions");

            migrationBuilder.RenameIndex(
                name: "IX_CarDescriptions_CarId",
                table: "Descriptions",
                newName: "IX_Descriptions_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Descriptions",
                table: "Descriptions",
                column: "CarDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Cars_CarId",
                table: "Descriptions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
