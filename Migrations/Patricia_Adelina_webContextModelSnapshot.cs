﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patricia_Adelina_web.Data;

#nullable disable

namespace Patricia_Adelina_web.Migrations
{
    [DbContext(typeof(Patricia_Adelina_webContext))]
    partial class Patricia_Adelina_webContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Patricia_Adelina_web.Models.Actor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.ActorFilm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<int?>("GenID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ActorID");

                    b.HasIndex("FilmID");

                    b.HasIndex("GenID");

                    b.ToTable("ActorFilm");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ActorID")
                        .HasColumnType("int");

                    b.Property<int?>("GenID")
                        .HasColumnType("int");

                    b.Property<int?>("OrarID")
                        .HasColumnType("int");

                    b.Property<decimal>("PretBilet")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Titlu")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("ActorID");

                    b.HasIndex("GenID");

                    b.HasIndex("OrarID");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Gen", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeGen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Gen");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Orar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Zi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Orar");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Vizionare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataVizionare")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FilmID")
                        .HasColumnType("int");

                    b.Property<int?>("VizionatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FilmID");

                    b.HasIndex("VizionatorID");

                    b.ToTable("Vizionare");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Vizionator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localitate")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Nume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vizionator");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.ActorFilm", b =>
                {
                    b.HasOne("Patricia_Adelina_web.Models.Actor", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Patricia_Adelina_web.Models.Film", "Film")
                        .WithMany("ActoriFilme")
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Patricia_Adelina_web.Models.Gen", null)
                        .WithMany("ActoriFilme")
                        .HasForeignKey("GenID");

                    b.Navigation("Actor");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Film", b =>
                {
                    b.HasOne("Patricia_Adelina_web.Models.Actor", "Actor")
                        .WithMany("Filme")
                        .HasForeignKey("ActorID");

                    b.HasOne("Patricia_Adelina_web.Models.Gen", "Gen")
                        .WithMany()
                        .HasForeignKey("GenID");

                    b.HasOne("Patricia_Adelina_web.Models.Orar", null)
                        .WithMany("Filme")
                        .HasForeignKey("OrarID");

                    b.Navigation("Actor");

                    b.Navigation("Gen");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Vizionare", b =>
                {
                    b.HasOne("Patricia_Adelina_web.Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmID");

                    b.HasOne("Patricia_Adelina_web.Models.Vizionator", "Vizionator")
                        .WithMany("Vizionari")
                        .HasForeignKey("VizionatorID");

                    b.Navigation("Film");

                    b.Navigation("Vizionator");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Actor", b =>
                {
                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Film", b =>
                {
                    b.Navigation("ActoriFilme");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Gen", b =>
                {
                    b.Navigation("ActoriFilme");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Orar", b =>
                {
                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Patricia_Adelina_web.Models.Vizionator", b =>
                {
                    b.Navigation("Vizionari");
                });
#pragma warning restore 612, 618
        }
    }
}
