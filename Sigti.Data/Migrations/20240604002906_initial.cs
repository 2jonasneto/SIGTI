using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigti.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "Varchar(50)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "Varchar(100)", nullable: false),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "Varchar(50)", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Computadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostName = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Processador = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Memoria = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Disco = table.Column<string>(type: "Varchar(150)", nullable: false),
                    Ip = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Anydesk = table.Column<string>(type: "Varchar(20)", nullable: false),
                    Grupos = table.Column<string>(type: "Varchar(150)", nullable: false),
                    UltimoUsuarioLogado = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Patrimonio = table.Column<string>(type: "Varchar(20)", nullable: false),
                    SistemaOperacional = table.Column<string>(type: "Varchar(100)", nullable: false),
                    SetorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocalizacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacao = table.Column<string>(type: "Varchar(300)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModificadoPor = table.Column<string>(type: "Varchar(50)", nullable: true),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computadores_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Computadores_Setores_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    ModificadoPor = table.Column<string>(type: "Varchar(50)", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Impressoras_Setores_SetorId",
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

            migrationBuilder.InsertData(
                table: "Localizacoes",
                columns: new[] { "Id", "Ativo", "DataModificacao", "Descricao", "ModificadoPor", "Nome" },
                values: new object[] { new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"), true, new DateTime(2024, 6, 3, 21, 29, 5, 921, DateTimeKind.Local).AddTicks(694), "", "SYSTEM", "MATRIZ" });

            migrationBuilder.InsertData(
                table: "Setores",
                columns: new[] { "Id", "Ativo", "DataModificacao", "Descricao", "LocalizacaoId", "ModificadoPor", "Nome" },
                values: new object[] { new Guid("7990de56-a99f-430e-b3bf-3ecddc8fe038"), true, new DateTime(2024, 6, 3, 21, 29, 5, 921, DateTimeKind.Local).AddTicks(850), "", new Guid("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"), "SYSTEM", "GERAL" });

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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computadores_LocalizacaoId",
                table: "Computadores",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Computadores_SetorId",
                table: "Computadores",
                column: "SetorId");

            migrationBuilder.CreateIndex(
                name: "IX_Controladoras_LocalizacaoId",
                table: "Controladoras",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Controladoras_SetorId",
                table: "Controladoras",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcessoControladoras");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Computadores");

            migrationBuilder.DropTable(
                name: "Impressoras");

            migrationBuilder.DropTable(
                name: "Controladoras");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Setores");

            migrationBuilder.DropTable(
                name: "Localizacoes");
        }
    }
}
