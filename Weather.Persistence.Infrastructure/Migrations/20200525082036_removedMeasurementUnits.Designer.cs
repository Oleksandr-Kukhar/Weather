﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.Persistence.Infrastructure;

namespace Weather.Persistence.Infrastructure.Migrations
{
    [DbContext(typeof(SensorsDataBaseContext))]
    [Migration("20200525082036_removedMeasurementUnits")]
    partial class removedMeasurementUnits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weather.Persistence.Model.Humidity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Humidity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf110ad6-c158-47f3-b5b2-c1cb5cd02c21"),
                            RegisterTime = new DateTime(2020, 5, 25, 11, 20, 35, 875, DateTimeKind.Local).AddTicks(7070),
                            Value = 50.0
                        });
                });

            modelBuilder.Entity("Weather.Persistence.Model.Pressure", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pressure");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe753342-7427-4b80-baa6-48da3a2c2350"),
                            RegisterTime = new DateTime(2020, 5, 25, 11, 20, 35, 875, DateTimeKind.Local).AddTicks(4944),
                            Value = 1010.0
                        });
                });

            modelBuilder.Entity("Weather.Persistence.Model.Temperature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Temperature");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a8c8e1cb-e3e2-48b9-801c-d9b905c6210d"),
                            RegisterTime = new DateTime(2020, 5, 25, 11, 20, 35, 872, DateTimeKind.Local).AddTicks(2685),
                            Value = 14.0
                        });
                });

            modelBuilder.Entity("Weather.Persistence.Model.Wind", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Speed")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Wind");

                    b.HasData(
                        new
                        {
                            Id = new Guid("090898fb-c6ad-4527-871c-26c1d0d7c963"),
                            Direction = 0,
                            RegisterTime = new DateTime(2020, 5, 25, 11, 20, 35, 875, DateTimeKind.Local).AddTicks(9874),
                            Speed = 5.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}