using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "compte_client",
                columns: table => new
                {
                    ClientsId = table.Column<long>(type: "bigint", nullable: false),
                    ComptesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compte_client", x => new { x.ClientsId, x.ComptesId });
                    table.ForeignKey(
                        name: "FK_compte_client_client_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_compte_client_compte_ComptesId",
                        column: x => x.ComptesId,
                        principalTable: "compte",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compte_client_ComptesId",
                table: "compte_client",
                column: "ComptesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compte_client");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
