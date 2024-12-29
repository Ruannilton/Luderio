﻿// <auto-generated />
using Luderia.Infrastructure.Contexts.Catalog.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Luderia.Infrastructure.Contexts.Catalog.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    partial class CatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameGameType", b =>
                {
                    b.Property<int>("GamesBGGId")
                        .HasColumnType("integer");

                    b.Property<int>("TypesId")
                        .HasColumnType("integer");

                    b.HasKey("GamesBGGId", "TypesId");

                    b.HasIndex("TypesId");

                    b.ToTable("GameGameType");
                });

            modelBuilder.Entity("Luderia.Domain.Contexts.Catalog.Models.Game", b =>
                {
                    b.Property<int>("BGGId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BGGId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("integer");

                    b.Property<int>("MinAge")
                        .HasColumnType("integer");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("BGGId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("Luderia.Domain.Contexts.Catalog.Models.GameItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("boolean");

                    b.Property<string>("Damages")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("GameItems", (string)null);
                });

            modelBuilder.Entity("Luderia.Domain.Contexts.Catalog.Models.GameType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("GameTypes", (string)null);
                });

            modelBuilder.Entity("GameGameType", b =>
                {
                    b.HasOne("Luderia.Domain.Contexts.Catalog.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesBGGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Luderia.Domain.Contexts.Catalog.Models.GameType", null)
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Luderia.Domain.Contexts.Catalog.Models.GameItem", b =>
                {
                    b.HasOne("Luderia.Domain.Contexts.Catalog.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
