﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Szilveszter_Levente_Proiect.Data;

#nullable disable

namespace Szilveszter_Levente_Proiect.Migrations
{
    [DbContext(typeof(Szilveszter_Levente_ProiectContext))]
    partial class Szilveszter_Levente_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Caller", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CallerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Caller");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Sender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sender");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Shipment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("BookingDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CallerID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("SenderID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CallerID");

                    b.HasIndex("SenderID");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.ShipmentCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ShipmentID");

                    b.ToTable("ShipmentCategory");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Shipment", b =>
                {
                    b.HasOne("Szilveszter_Levente_Proiect.Models.Caller", "Caller")
                        .WithMany("Shipments")
                        .HasForeignKey("CallerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Szilveszter_Levente_Proiect.Models.Sender", "Sender")
                        .WithMany("Shipments")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caller");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.ShipmentCategory", b =>
                {
                    b.HasOne("Szilveszter_Levente_Proiect.Models.Category", "Category")
                        .WithMany("ShipmentCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Szilveszter_Levente_Proiect.Models.Shipment", "Shipment")
                        .WithMany("ShipmentCategories")
                        .HasForeignKey("ShipmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Shipment");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Caller", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Category", b =>
                {
                    b.Navigation("ShipmentCategories");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Sender", b =>
                {
                    b.Navigation("Shipments");
                });

            modelBuilder.Entity("Szilveszter_Levente_Proiect.Models.Shipment", b =>
                {
                    b.Navigation("ShipmentCategories");
                });
#pragma warning restore 612, 618
        }

    }
}

