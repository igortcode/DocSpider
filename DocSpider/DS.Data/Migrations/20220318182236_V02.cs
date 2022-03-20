using Microsoft.EntityFrameworkCore.Migrations;

namespace DS.Data.Migrations
{
    public partial class V02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo");

            migrationBuilder.RenameTable(
                name: "Log",
                newName: "Logs");

            migrationBuilder.RenameTable(
                name: "Arquivo",
                newName: "Arquivos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arquivos",
                table: "Arquivos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_Nome",
                table: "Arquivos",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Arquivos",
                table: "Arquivos");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_Nome",
                table: "Arquivos");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "Log");

            migrationBuilder.RenameTable(
                name: "Arquivos",
                newName: "Arquivo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Arquivo",
                table: "Arquivo",
                column: "Id");
        }
    }
}
