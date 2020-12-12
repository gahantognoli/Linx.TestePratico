using Microsoft.EntityFrameworkCore.Migrations;

namespace Linx.Player.Data.Migrations
{
    public partial class AlteracaoIdiomaMusicaParaInteiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Idioma",
                table: "Musicas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Idioma",
                table: "Musicas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
