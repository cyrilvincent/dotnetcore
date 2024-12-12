using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Configuration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Comptes_CompteId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comptes",
                table: "Comptes");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "transaction");

            migrationBuilder.RenameTable(
                name: "Comptes",
                newName: "compte");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "transaction",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Montant",
                table: "transaction",
                newName: "montant");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "transaction",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "transaction",
                newName: "date_time");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_CompteId",
                table: "transaction",
                newName: "IX_transaction_CompteId");

            migrationBuilder.RenameColumn(
                name: "Solde",
                table: "compte",
                newName: "solde");

            migrationBuilder.RenameColumn(
                name: "Devise",
                table: "compte",
                newName: "devise");

            migrationBuilder.RenameColumn(
                name: "Commentaire",
                table: "compte",
                newName: "commentaire");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "compte",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "devise",
                table: "compte",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "commentaire",
                table: "compte",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction",
                table: "transaction",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_compte",
                table: "compte",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_compte_CompteId",
                table: "transaction",
                column: "CompteId",
                principalTable: "compte",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transaction_compte_CompteId",
                table: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction",
                table: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compte",
                table: "compte");

            migrationBuilder.RenameTable(
                name: "transaction",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "compte",
                newName: "Comptes");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Transaction",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "montant",
                table: "Transaction",
                newName: "Montant");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transaction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "date_time",
                table: "Transaction",
                newName: "DateTime");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_CompteId",
                table: "Transaction",
                newName: "IX_Transaction_CompteId");

            migrationBuilder.RenameColumn(
                name: "solde",
                table: "Comptes",
                newName: "Solde");

            migrationBuilder.RenameColumn(
                name: "devise",
                table: "Comptes",
                newName: "Devise");

            migrationBuilder.RenameColumn(
                name: "commentaire",
                table: "Comptes",
                newName: "Commentaire");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comptes",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Devise",
                table: "Comptes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Commentaire",
                table: "Comptes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comptes",
                table: "Comptes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Comptes_CompteId",
                table: "Transaction",
                column: "CompteId",
                principalTable: "Comptes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
