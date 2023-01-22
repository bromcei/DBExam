﻿// <auto-generated />
using System;
using DBExam.DbContextServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBExam.Migrations
{
    [DbContext(typeof(HoneyBadgerDbContext))]
    [Migration("20230122142629_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DBExam.Classes.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DBExam.Classes.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchasePrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DBExam.Classes.Suplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SuplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Supliers");
                });

            modelBuilder.Entity("ProductSuplier", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuplierListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductsId", "SuplierListId");

                    b.HasIndex("SuplierListId");

                    b.ToTable("ProductSuplier");
                });

            modelBuilder.Entity("DBExam.Classes.Product", b =>
                {
                    b.HasOne("DBExam.Classes.Department", null)
                        .WithMany("Products")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("DBExam.Classes.Suplier", b =>
                {
                    b.HasOne("DBExam.Classes.Department", null)
                        .WithMany("Supliers")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("ProductSuplier", b =>
                {
                    b.HasOne("DBExam.Classes.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBExam.Classes.Suplier", null)
                        .WithMany()
                        .HasForeignKey("SuplierListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DBExam.Classes.Department", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Supliers");
                });
#pragma warning restore 612, 618
        }
    }
}