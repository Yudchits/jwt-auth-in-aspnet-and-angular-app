﻿// <auto-generated />
using System;
using Marketplace.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Marketplace.DataAccess.Migrations
{
    [DbContext(typeof(MarketplaceContext))]
    [Migration("20241111132147_AddedEngineTable")]
    partial class AddedEngineTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Marketplace.DataAccess.Common.Models.CarDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int?>("EngineId")
                        .HasColumnType("int");

                    b.Property<string>("Generation")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Marketplace.DataAccess.Common.Models.EngineDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Capacity")
                        .HasColumnType("float");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("Marketplace.DataAccess.Common.Models.CarDb", b =>
                {
                    b.HasOne("Marketplace.DataAccess.Common.Models.EngineDb", "Engine")
                        .WithMany("Cars")
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("Marketplace.DataAccess.Common.Models.EngineDb", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}