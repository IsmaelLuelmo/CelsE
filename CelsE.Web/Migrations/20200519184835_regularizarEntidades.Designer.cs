﻿// <auto-generated />
using System;
using CelsE.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CelsE.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200519184835_regularizarEntidades")]
    partial class regularizarEntidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CelsE.Web.Data.Entity.AlumnoEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("Curso")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("Direccion");

                    b.Property<string>("EmailAlumno");

                    b.Property<string>("EmailMadre");

                    b.Property<string>("EmailPadre");

                    b.Property<string>("Localidad");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("NombreMadre");

                    b.Property<string>("NombrePadre");

                    b.Property<string>("Observaciones");

                    b.Property<string>("TelefonoAlumno");

                    b.Property<string>("TelefonoMadre");

                    b.Property<string>("TelefonoPadre");

                    b.Property<string>("UsuarioId");

                    b.HasKey("ID");

                    b.HasIndex("DNI")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.ParteEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlumnoID");

                    b.Property<string>("ComunicacionPadres");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<string>("MedidasAdoptadas");

                    b.Property<string>("Observaciones");

                    b.Property<int?>("ProfesorID");

                    b.HasKey("ID");

                    b.HasIndex("AlumnoID");

                    b.HasIndex("ProfesorID");

                    b.ToTable("Parte");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.ProfesorEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("EmailProfesor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("Observaciones");

                    b.Property<string>("TelefonoProfesor");

                    b.Property<string>("UsuarioId");

                    b.HasKey("ID");

                    b.HasIndex("DNI")
                        .IsUnique();

                    b.HasIndex("UsuarioId");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("Direccion")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FotoPath");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("TipoUsuario");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int?>("UserGroupEntityId");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserGroupEntityId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.UserGroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("GrupoUsuarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.AlumnoEntity", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.ParteEntity", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.AlumnoEntity", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoID");

                    b.HasOne("CelsE.Web.Data.Entity.ProfesorEntity", "Profesor")
                        .WithMany()
                        .HasForeignKey("ProfesorID");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.ProfesorEntity", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.UserEntity", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserGroupEntity")
                        .WithMany("Usuarios")
                        .HasForeignKey("UserGroupEntityId");
                });

            modelBuilder.Entity("CelsE.Web.Data.Entity.UserGroupEntity", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CelsE.Web.Data.Entity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CelsE.Web.Data.Entity.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
