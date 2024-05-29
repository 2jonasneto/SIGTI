using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sigti.Data.Migrations
{
    /// <inheritdoc />
    public partial class configComputador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores");

            migrationBuilder.AlterColumn<string>(
                name: "UltimoUsuarioLogado",
                table: "Computadores",
                type: "Varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SistemaOperacional",
                table: "Computadores",
                type: "Varchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Processador",
                table: "Computadores",
                type: "Varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patrimonio",
                table: "Computadores",
                type: "Varchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Computadores",
                type: "Varchar(300)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Memoria",
                table: "Computadores",
                type: "Varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Computadores",
                type: "Varchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HostName",
                table: "Computadores",
                type: "Varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Grupos",
                table: "Computadores",
                type: "Varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Disco",
                table: "Computadores",
                type: "Varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Anydesk",
                table: "Computadores",
                type: "Varchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores",
                column: "Processador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores");

            migrationBuilder.AlterColumn<string>(
                name: "UltimoUsuarioLogado",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "SistemaOperacional",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Patrimonio",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(300)");

            migrationBuilder.AlterColumn<string>(
                name: "Memoria",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "HostName",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Grupos",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Disco",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Anydesk",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Processador",
                table: "Computadores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(150)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computadores",
                table: "Computadores",
                column: "Id");
        }
    }
}
