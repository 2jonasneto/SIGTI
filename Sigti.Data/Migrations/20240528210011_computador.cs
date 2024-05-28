using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigti.Data.Migrations
{
    /// <inheritdoc />
    public partial class computador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anydesk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grupos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoUsuarioLogado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patrimonio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SistemaOperacional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computadores");
        }
    }
}
