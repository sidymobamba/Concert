﻿// <auto-generated />
using Concert.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Concert.Migrations
{
    [DbContext(typeof(ConcertContext))]
    [Migration("20240516090221_p2")]
    partial class p2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Concert.Entities.TicketEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("CO2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");

                    b.HasData(
                        new
                        {
                            Id = "db34",
                            CO2 = 23455m,
                            UserId = "fg32"
                        },
                        new
                        {
                            Id = "fv45",
                            CO2 = 23455m,
                            UserId = "35f4"
                        });
                });

            modelBuilder.Entity("Concert.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MeansOfTransport")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "fg32",
                            City = "Brescia",
                            MeansOfTransport = "Car",
                            Name = "Sidy",
                            Surname = "Samb"
                        },
                        new
                        {
                            Id = "35f4",
                            City = "Milano",
                            MeansOfTransport = "Train",
                            Name = "Pippo",
                            Surname = "Caio"
                        });
                });

            modelBuilder.Entity("Concert.Entities.TicketEntity", b =>
                {
                    b.HasOne("Concert.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
