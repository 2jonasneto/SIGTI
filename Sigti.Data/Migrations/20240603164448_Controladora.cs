using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigti.Data.Migrations
{
    /// <inheritdoc />
    public partial class Controladora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Setores",
                keyColumn: "Id",
                keyValue: new Guid("ec69e422-fb19-4aa4-a50e-3e75fd75fca0"));

            migrationBuilder.RenameColumn(
                name: "Varchar(50)",
                table: "Setores",
                newName: "ModificadoPor");

            migrationBuilder.RenameColumn(
                name: "Varchar(50)",
                table: "Localizacoes",
                newName: "ModificadoPor");

            migrationBuilder.RenameColumn(
                name: "Varchar(50)",
                table: "Impressoras",
                newName: "ModificadoPor");

            migrationBuilder.RenameColumn(
                name: "Varchar(50)",
                table: "Computadores",
                newName: "ModificadoPor");

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPor",
                table: "Setores",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPor",
                table: "Localizacoes",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPor",
                table: "Impressoras",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPor",
                table: "Computadores",
                type: "Varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Controladoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(100)", nullable: false),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "Varchar(50)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controladoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Controladoras_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Controladoras_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcessoControladoras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Observacao = table.Column<string>(type: "Varchar(200)", nullable: false),
                    DigitalId = table.Column<string>(type: "Varchar(20)", nullable: false),
                    ControladoraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "Varchar(50)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoControladoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcessoControladoras_Controladoras_ControladoraId",
                        column: x => x.ControladoraId,
                        principalTable: "Controladoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcessoControladoras_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcessoControladoras_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Localizacoes",
                keyColumn: "Id",
                keyValue: new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"),
                column: "DataModificacao",
                value: new DateTime(2024, 6, 3, 13, 44, 48, 385, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "Ativo", "DataModificacao", "Descricao", "LocalizacaoId", "ModificadoPor", "Nome" },
                values: new object[] { new Guid("38f56217-8b66-4b4b-9d40-563f350e8cb4"), true, new DateTime(2024, 6, 3, 13, 44, 48, 385, DateTimeKind.Local).AddTicks(8445), "", new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"), "SYSTEM", "GERAL" });

            migrationBuilder.CreateIndex(
                name: "IX_AcessoControladoras_ControladoraId",
                table: "AcessoControladoras",
                column: "ControladoraId");

            migrationBuilder.CreateIndex(
                name: "IX_AcessoControladoras_LocalizacaoId",
                table: "AcessoControladoras",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AcessoControladoras_SetorId",
                table: "AcessoControladoras",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Controladoras_LocalizacaoId",
                table: "Controladoras",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Controladoras_SetorId",
                table: "Controladoras",
                column: "SetorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoControladoras");

            migrationBuilder.DropTable(
                name: "Controladoras");

            migrationBuilder.DeleteData(
                table: "Setores",
                keyColumn: "Id",
                keyValue: new Guid("38f56217-8b66-4b4b-9d40-563f350e8cb4"));

            migrationBuilder.RenameColumn(
                name: "ModificadoPor",
                table: "Setores",
                newName: "Varchar(50)");

            migrationBuilder.RenameColumn(
                name: "ModificadoPor",
                table: "Localizacoes",
                newName: "Varchar(50)");

            migrationBuilder.RenameColumn(
                name: "ModificadoPor",
                table: "Impressoras",
                newName: "Varchar(50)");

            migrationBuilder.RenameColumn(
                name: "ModificadoPor",
                table: "Computadores",
                newName: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(50)",
                table: "Setores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(50)",
                table: "Localizacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(50)",
                table: "Impressoras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Varchar(50)",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Localizacoes",
                keyColumn: "Id",
                keyValue: new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"),
                column: "DataModificacao",
                value: new DateTime(2024, 5, 29, 17, 56, 6, 613, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "Ativo", "DataModificacao", "Descricao", "LocalizacaoId", "Varchar(50)", "Nome" },
                values: new object[] { new Guid("ec69e422-fb19-4aa4-a50e-3e75fd75fca0"), true, new DateTime(2024, 5, 29, 17, 56, 6, 613, DateTimeKind.Local).AddTicks(2844), "", new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"), "SYSTEM", "MATRIZ" });
        }
    }
}
