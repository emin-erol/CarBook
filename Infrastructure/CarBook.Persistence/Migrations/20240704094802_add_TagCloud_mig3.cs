using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_TagCloud_mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Blogs_BlogId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "TagClouds");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_BlogId",
                table: "TagClouds",
                newName: "IX_TagClouds_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagClouds",
                table: "TagClouds",
                column: "TagCloudId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagClouds_Blogs_BlogId",
                table: "TagClouds",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagClouds_Blogs_BlogId",
                table: "TagClouds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagClouds",
                table: "TagClouds");

            migrationBuilder.RenameTable(
                name: "TagClouds",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_TagClouds_BlogId",
                table: "Tags",
                newName: "IX_Tags_BlogId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagCloudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Blogs_BlogId",
                table: "Tags",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
