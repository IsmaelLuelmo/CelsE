using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CelsE.Web.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParteEntity");

            migrationBuilder.DropTable(
                name: "ProfesorEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_alumnos",
                table: "alumnos");

            migrationBuilder.RenameTable(
                name: "alumnos",
                newName: "Alumnos");

            migrationBuilder.RenameIndex(
                name: "IX_alumnos_DNI",
                table: "Alumnos",
                newName: "IX_Alumnos_DNI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DNI = table.Column<string>(maxLength: 9, nullable: false),
                    Nombre = table.Column<string>(maxLength: 35, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 35, nullable: false),
                    TelefonoProfesor = table.Column<string>(nullable: true),
                    EmailProfesor = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Parte",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    MedidasAdoptadas = table.Column<string>(nullable: true),
                    ProfesorID = table.Column<int>(nullable: true),
                    AlumnoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parte", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Parte_Alumnos_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumnos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Parte_Profesor_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "Profesor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parte_AlumnoID",
                table: "Parte",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_Parte_ProfesorID",
                table: "Parte",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_DNI",
                table: "Profesor",
                column: "DNI",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parte");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "Alumnos",
                newName: "alumnos");

            migrationBuilder.RenameIndex(
                name: "IX_Alumnos_DNI",
                table: "alumnos",
                newName: "IX_alumnos_DNI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_alumnos",
                table: "alumnos",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ProfesorEntity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(maxLength: 35, nullable: false),
                    DNI = table.Column<string>(maxLength: 9, nullable: false),
                    EmailProfesor = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 35, nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    TelefonoProfesor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorEntity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParteEntity",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlumnoID = table.Column<int>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    MedidasAdoptadas = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    ProfesorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParteEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ParteEntity_alumnos_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "alumnos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParteEntity_ProfesorEntity_ProfesorID",
                        column: x => x.ProfesorID,
                        principalTable: "ProfesorEntity",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParteEntity_AlumnoID",
                table: "ParteEntity",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_ParteEntity_ProfesorID",
                table: "ParteEntity",
                column: "ProfesorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorEntity_DNI",
                table: "ProfesorEntity",
                column: "DNI",
                unique: true);
        }
    }
}
