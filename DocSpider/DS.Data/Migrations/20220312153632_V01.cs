using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DS.Data.Migrations
{
    public partial class V01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arquivo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "ntext", maxLength: 2000, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dados = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mensagem = table.Column<string>(type: "ntext", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivo");

            migrationBuilder.DropTable(
                name: "Log");
        }
    }
}
