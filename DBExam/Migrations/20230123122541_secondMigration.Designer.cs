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
    [Migration("20230123122541_secondMigration")]
    partial class secondMigration
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
                    b.Property<Guid>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProduct", b =>
                {
                    b.Property<Guid>("HoneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentID")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HoneyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HoneyId");

                    b.HasIndex("DepartmentID");

                    b.ToTable("HoneyProducts");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProductSupplier", b =>
                {
                    b.Property<Guid>("HoneyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HoneyProductHoneyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HoneyId", "SupplierId");

                    b.HasIndex("HoneyProductHoneyId");

                    b.HasIndex("SupplierId");

                    b.ToTable("HoneyProductsSupliers");
                });

            modelBuilder.Entity("DBExam.Classes.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DepartmentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProduct", b =>
                {
                    b.HasOne("DBExam.Classes.Department", "ProductDepartment")
                        .WithMany("HoneyProducts")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductDepartment");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProductSupplier", b =>
                {
                    b.HasOne("DBExam.Classes.HoneyProduct", "HoneyProduct")
                        .WithMany("HoneyProductSuppliers")
                        .HasForeignKey("HoneyProductHoneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBExam.Classes.Supplier", "Supplier")
                        .WithMany("HoneyProductSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoneyProduct");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("DBExam.Classes.Supplier", b =>
                {
                    b.HasOne("DBExam.Classes.Department", "SupplierDepartment")
                        .WithMany("Suppliers")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SupplierDepartment");
                });

            modelBuilder.Entity("DBExam.Classes.Department", b =>
                {
                    b.Navigation("HoneyProducts");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProduct", b =>
                {
                    b.Navigation("HoneyProductSuppliers");
                });

            modelBuilder.Entity("DBExam.Classes.Supplier", b =>
                {
                    b.Navigation("HoneyProductSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}