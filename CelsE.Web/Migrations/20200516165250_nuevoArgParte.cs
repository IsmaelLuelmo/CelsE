using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsE.Web.Migrations
{
    public partial class nuevoArgParte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComunicacionPadres",
                table: "Parte",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComunicacionPadres",
                table: "Parte");
        }
    }
}
