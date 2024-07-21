using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Cars_CarId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_CarId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Features",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarId",
                table: "Features",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Cars_CarId",
                table: "Features",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "CarId");
        }
    }
}
