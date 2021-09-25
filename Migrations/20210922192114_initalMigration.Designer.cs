﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleATMSystem;

namespace SimpleATMSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210922192114_initalMigration")]
    partial class initalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleATMSystem.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PinHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = 123456789,
                            Balance = 2340m,
                            DateOfBirth = new DateTime(1990, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            LastName = "Smith",
                            PinHash = "ciSYdF0TrB96wOl27yYEcA==fXF2p7e34GRipBh1ptxvKwNEcMdgp/IC0wbOG+RVBhw="
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = 111111111,
                            Balance = 3120m,
                            DateOfBirth = new DateTime(1993, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mary",
                            LastName = "Green",
                            PinHash = "rbScURTPhTZ65H35ejN5BA==J5cNESF22JVk7jj1wP+gR32C4cIXUnaOMFVzVEjN5M8="
                        });
                });
#pragma warning restore 612, 618
        }
    }
}