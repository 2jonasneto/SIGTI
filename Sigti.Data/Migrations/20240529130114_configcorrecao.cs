using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigti.Data.Migrations
{
    /// <inheritdoc />
    public partial class configcorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setores_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Impressoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Patrimonio = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Alugado = table.Column<bool>(type: "bit", nullable: false),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "Varchar(300)", nullable: false),
                    Ip = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Conexao = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impressoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impressoras_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Impressoras_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computadores_LocalizacaoId",
                table: "Computadores",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Computadores_SetorId",
                table: "Computadores",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Impressoras_LocalizacaoId",
                table: "Impressoras",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Impressoras_SetorId",
                table: "Impressoras",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Setores_LocalizacaoId",
                table: "Setores",
                column: "LocalizacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computadores_Localizacoes_LocalizacaoId",
                table: "Computadores",
                column: "LocalizacaoId",
                principalTable: "Localizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computadores_Setores_SetorId",
                table: "Computadores",
                column: "SetorId",
                principalTable: "Setores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computadores_Localizacoes_LocalizacaoId",
                table: "Computadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Computadores_Setores_SetorId",
                table: "Computadores");

            migrationBuilder.DropTable(
                name: "Impressoras");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores");

            migrationBuilder.DropIndex(
                name: "IX_Computadores_LocalizacaoId",
                table: "Computadores");

            migrationBuilder.DropIndex(
                name: "IX_Computadores_SetorId",
                table: "Computadores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores",
                column: "Processador");
        }
    }
}
