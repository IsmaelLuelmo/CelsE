using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsE.Web.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Profesor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido1",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Apellido2",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "AspNetUsers",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FotoPath",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuario",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserGroupEntityId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GrupoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoUsuarios_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_UsuarioId",
                table: "Profesor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserGroupEntityId",
                table: "AspNetUsers",
                column: "UserGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoUsuarios_UsuarioId",
                table: "GrupoUsuarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_GrupoUsuarios_UserGroupEntityId",
                table: "AspNetUsers",
                column: "UserGroupEntityId",
                principalTable: "GrupoUsuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesor_AspNetUsers_UsuarioId",
                table: "Profesor",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_GrupoUsuarios_UserGroupEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesor_AspNetUsers_UsuarioId",
                table: "Profesor");

            migrationBuilder.DropTable(
                name: "GrupoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_Profesor_UsuarioId",
                table: "Profesor");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserGroupEntityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Profesor");

            migrationBuilder.DropColumn(
                name: "Apellido1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Apellido2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FotoPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserGroupEntityId",
                table: "AspNetUsers");
        }
    }
}
