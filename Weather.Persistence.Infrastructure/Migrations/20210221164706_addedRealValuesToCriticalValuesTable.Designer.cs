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
    [Migration("20210221164706_addedRealValuesToCriticalValuesTable")]
    partial class addedRealValuesToCriticalValuesTable
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
                            Id = new Guid("b74322db-e363-4827-9812-8032d866cb7f"),
                            Value = 0.0,
                            ValueName = "MinimalWindSpeed"
                        },
                        new
                        {
                            Id = new Guid("93b28cdd-0354-419e-b3e7-360eaa8d9ac8"),
                            Value = 10.0,
                            ValueName = "MaximalWindSpeed"
                        },
                        new
                        {
                            Id = new Guid("fd966929-c95a-478b-8e9e-ab043c720bd9"),
                            Value = 1000.0,
                            ValueName = "MinimalPressure"
                        },
                        new
                        {
                            Id = new Guid("6229a34a-74a6-4aaa-9ece-486a55a0330b"),
                            Value = 1100.0,
                            ValueName = "MaximalPressure"
                        },
                        new
                        {
                            Id = new Guid("c386ebb5-fa6a-4953-8f4b-d2a1c2b82e1e"),
                            Value = 30.0,
                            ValueName = "MinimalHumidity"
                        },
                        new
                        {
                            Id = new Guid("fec82ea5-d7f5-47e9-b5cf-dcfa9f956ee7"),
                            Value = 100.0,
                            ValueName = "MaximalHumidity"
                        },
                        new
                        {
                            Id = new Guid("fe4aad14-1a5c-48be-8be3-8eb14b051190"),
                            Value = 278.0,
                            ValueName = "MinimalTemperature"
                        },
                        new
                        {
                            Id = new Guid("21f8314b-f37f-4c73-9bcb-52b0e7aea45a"),
                            Value = 288.0,
                            ValueName = "MaximalTemperature"
                        },
                        new
                        {
                            Id = new Guid("7058de6b-b2e9-4de5-b919-400dd87fe38e"),
                            Value = 0.0,
                            ValueName = "MinimalRealWindSpeed"
                        },
                        new
                        {
                            Id = new Guid("212a0295-ad9e-42c7-9fda-24aec2e69527"),
                            Value = 10.0,
                            ValueName = "MaximalRealWindSpeed"
                        },
                        new
                        {
                            Id = new Guid("69179feb-761e-4439-a741-4b37213e21d0"),
                            Value = 1000.0,
                            ValueName = "MinimalRealPressure"
                        },
                        new
                        {
                            Id = new Guid("54554279-9152-4a5a-9b31-a90660401a57"),
                            Value = 1100.0,
                            ValueName = "MaximalRealPressure"
                        },
                        new
                        {
                            Id = new Guid("38b1c9f0-f7f8-46e6-aa06-65ef42605852"),
                            Value = 30.0,
                            ValueName = "MinimalRealHumidity"
                        },
                        new
                        {
                            Id = new Guid("ba5773d5-b34e-407b-8eb1-b59aabbe0a6e"),
                            Value = 100.0,
                            ValueName = "MaximalRealHumidity"
                        },
                        new
                        {
                            Id = new Guid("a2bee0a1-a808-46cd-9854-79e8bd9d5c58"),
                            Value = 278.0,
                            ValueName = "MinimalRealTemperature"
                        },
                        new
                        {
                            Id = new Guid("4034b082-eb68-4857-a2fb-9c042611f238"),
                            Value = 288.0,
                            ValueName = "MaximalRealTemperature"
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