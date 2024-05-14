using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormationASPNETCore.Migrations
{
    /// <inheritdoc />
    public partial class Book2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_publisher_PublisherId",
                schema: "public",
                table: "media");

            migrationBuilder.RenameColumn(
                name: "Comment",
                schema: "public",
                table: "media",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "PublisherId",
                schema: "public",
                table: "media",
                newName: "publisher_id");

            migrationBuilder.RenameIndex(
                name: "IX_media_PublisherId",
                schema: "public",
                table: "media",
                newName: "IX_media_publisher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_media_publisher_publisher_id",
                schema: "public",
                table: "media",
                column: "publisher_id",
                principalSchema: "public",
                principalTable: "publisher",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_publisher_publisher_id",
                schema: "public",
                table: "media");

            migrationBuilder.RenameColumn(
                name: "comment",
                schema: "public",
                table: "media",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "publisher_id",
                schema: "public",
                table: "media",
                newName: "PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_media_publisher_id",
                schema: "public",
                table: "media",
                newName: "IX_media_PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_media_publisher_PublisherId",
                schema: "public",
                table: "media",
                column: "PublisherId",
                principalSchema: "public",
                principalTable: "publisher",
                principalColumn: "id");
        }
    }
}
