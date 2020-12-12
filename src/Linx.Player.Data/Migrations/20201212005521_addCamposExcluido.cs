using Microsoft.EntityFrameworkCore.Migrations;

namespace Linx.Player.Data.Migrations
{
    public partial class addCamposExcluido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Musicas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Generos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Artistas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Albuns",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Musicas");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Albuns");
        }
    }
}
