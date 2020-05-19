using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsE.Web.Migrations
{
    public partial class regularizarEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Alumnos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_UsuarioId",
                table: "Alumnos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_AspNetUsers_UsuarioId",
                table: "Alumnos",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_AspNetUsers_UsuarioId",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_UsuarioId",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Alumnos");
        }
    }
}
