﻿// <auto-generated />
using System;
using AEDProject.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AEDProject.Migrations
{
    [DbContext(typeof(AEDContext))]
    [Migration("20240513150051_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AEDProject.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AEDProject.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllAngels")
                        .HasColumnType("bit");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("date");

                    b.Property<DateOnly>("EXP")
                        .HasColumnType("date");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<bool>("HaveSelfie")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("ISS")
                        .HasColumnType("date");

                    b.Property<bool>("SSN")
                        .HasColumnType("bit");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<int>("Sides")
                        .HasColumnType("int");

                    b.Property<string>("strId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("AEDProject.Entities.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("AEDProject.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("strId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AEDProject.Entities.Country", b =>
                {
                    b.HasOne("AEDProject.Entities.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("AEDProject.Entities.Document", b =>
                {
                    b.HasOne("AEDProject.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AEDProject.Entities.Image", b =>
                {
                    b.HasOne("AEDProject.Entities.Document", null)
                        .WithMany("Images")
                        .HasForeignKey("DocumentId");
                });

            modelBuilder.Entity("AEDProject.Entities.Document", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}