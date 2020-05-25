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
    [Migration("20200525172748_addedCriticalValues")]
    partial class addedCriticalValues
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weather.Persistence.Model.CriticalValues", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.Property<string>("ValueName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CriticalValues");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b2bf9c0e-101c-4da5-8fe4-92a0ba2c1209"),
                            Value = 278.0,
                            ValueName = "MinimalTemperature"
                        },
                        new
                        {
                            Id = new Guid("52b24128-6129-4cb1-aeb4-1cd0c2ef5f54"),
                            Value = 288.0,
                            ValueName = "MaximalTemperature"
                        });
                });

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
                });
#pragma warning restore 612, 618
        }
    }
}
