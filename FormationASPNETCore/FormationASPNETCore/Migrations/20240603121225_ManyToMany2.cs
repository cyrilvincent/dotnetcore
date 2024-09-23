using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormationASPNETCore.Migrations
{
    /// <inheritdoc />
    public partial class ManyToMany2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorMedia_author_AuthorsId",
                schema: "public",
                table: "AuthorMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorMedia_media_MediasId",
                schema: "public",
                table: "AuthorMedia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorMedia",
                schema: "public",
                table: "AuthorMedia");

            migrationBuilder.RenameTable(
                name: "AuthorMedia",
                schema: "public",
                newName: "media_author",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorMedia_MediasId",
                schema: "public",
                table: "media_author",
                newName: "IX_media_author_MediasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_media_author",
                schema: "public",
                table: "media_author",
                columns: new[] { "AuthorsId", "MediasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_media_author_author_AuthorsId",
                schema: "public",
                table: "media_author",
                column: "AuthorsId",
                principalSchema: "public",
                principalTable: "author",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_media_author_media_MediasId",
                schema: "public",
                table: "media_author",
                column: "MediasId",
                principalSchema: "public",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_author_author_AuthorsId",
                schema: "public",
                table: "media_author");

            migrationBuilder.DropForeignKey(
                name: "FK_media_author_media_MediasId",
                schema: "public",
                table: "media_author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_media_author",
                schema: "public",
                table: "media_author");

            migrationBuilder.RenameTable(
                name: "media_author",
                schema: "public",
                newName: "AuthorMedia",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_media_author_MediasId",
                schema: "public",
                table: "AuthorMedia",
                newName: "IX_AuthorMedia_MediasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorMedia",
                schema: "public",
                table: "AuthorMedia",
                columns: new[] { "AuthorsId", "MediasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorMedia_author_AuthorsId",
                schema: "public",
                table: "AuthorMedia",
                column: "AuthorsId",
                principalSchema: "public",
                principalTable: "author",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorMedia_media_MediasId",
                schema: "public",
                table: "AuthorMedia",
                column: "MediasId",
                principalSchema: "public",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
