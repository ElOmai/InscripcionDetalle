﻿// <auto-generated />
using System;
using InscripcionDetalle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InscripcionDetalle.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("InscripcionDetalle.Models.Asignatura", b =>
                {
                    b.Property<int>("AsignaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Creditos")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PreRequisito")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AsignaturaId");

                    b.ToTable("Asignatura");
                });

            modelBuilder.Entity("InscripcionDetalle.Models.Estudiante", b =>
                {
                    b.Property<int>("EstudianteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EstudianteId");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("InscripcionDetalle.Models.Inscripcion", b =>
                {
                    b.Property<int>("InscripcionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Disponible")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Limite")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Monto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Semestre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tomados")
                        .HasColumnType("INTEGER");

                    b.HasKey("InscripcionId");

                    b.ToTable("Inscripcion");
                });

            modelBuilder.Entity("InscripcionDetalle.Models.InscripcionDetalles", b =>
                {
                    b.Property<int>("InscripcionDetallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AsignaturaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Creditos")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionAsignatura")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("InscripcionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Subtotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("InscripcionDetallesId");

                    b.HasIndex("InscripcionId");

                    b.ToTable("InscripcionDetalles");
                });

            modelBuilder.Entity("InscripcionDetalle.Models.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Monto")
                        .HasColumnType("INTEGER");

                    b.HasKey("PagoId");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("InscripcionDetalle.Models.InscripcionDetalles", b =>
                {
                    b.HasOne("InscripcionDetalle.Models.Inscripcion", null)
                        .WithMany("Detalles")
                        .HasForeignKey("InscripcionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
