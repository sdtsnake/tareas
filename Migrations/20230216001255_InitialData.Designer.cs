﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using proyectef;

#nullable disable

namespace proyectef.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20230216001255_InitialData")]
    partial class InitialData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("proyectef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("5be4dbfe-1be0-4e7e-9648-51e585602c40"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("5be4dbfe-1be0-4e7e-9648-51e585602c20"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("proyectef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("5be4dbfe-1be0-4e7e-9648-51e585602c45"),
                            CategoriaId = new Guid("5be4dbfe-1be0-4e7e-9648-51e585602c40"),
                            FechaCreacion = new DateTime(2023, 2, 15, 19, 12, 55, 157, DateTimeKind.Local).AddTicks(2558),
                            PrioridadTarea = 1,
                            Titulo = "Pagos de servicios publicos"
                        },
                        new
                        {
                            TareaId = new Guid("5be4dbfe-1be0-4e7e-9648-51e585602c25"),
                            CategoriaId = new Guid("5be4dbfe-1be0-4e7e-9648-51e585602c20"),
                            FechaCreacion = new DateTime(2023, 2, 15, 19, 12, 55, 157, DateTimeKind.Local).AddTicks(2574),
                            PrioridadTarea = 0,
                            Titulo = "Terminar capitulo de the last of us en hbo"
                        });
                });

            modelBuilder.Entity("proyectef.Models.Tarea", b =>
                {
                    b.HasOne("proyectef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}