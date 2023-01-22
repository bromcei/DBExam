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
    [Migration("20230122220836_tenthMigration")]
    partial class tenthMigration
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
                    b.Property<Guid>("DepartemntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DepartmentAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartemntId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProduct", b =>
                {
                    b.Property<Guid>("HoneyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HoneyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductDepartmentDepartemntId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HoneyId");

                    b.HasIndex("ProductDepartmentDepartemntId");

                    b.ToTable("HoneyProducts");
                });

            modelBuilder.Entity("DBExam.Classes.Supplier", b =>
                {
                    b.Property<Guid>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("DepartmentDepartemntId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.HasIndex("DepartmentDepartemntId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("HoneyProductSupplier", b =>
                {
                    b.Property<Guid>("HoneyProductsHoneyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplierListSupplierId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HoneyProductsHoneyId", "SupplierListSupplierId");

                    b.HasIndex("SupplierListSupplierId");

                    b.ToTable("HoneyProductSupplier");
                });

            modelBuilder.Entity("DBExam.Classes.HoneyProduct", b =>
                {
                    b.HasOne("DBExam.Classes.Department", "ProductDepartment")
                        .WithMany("HoneyProducts")
                        .HasForeignKey("ProductDepartmentDepartemntId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDepartment");
                });

            modelBuilder.Entity("DBExam.Classes.Supplier", b =>
                {
                    b.HasOne("DBExam.Classes.Department", null)
                        .WithMany("Suppliers")
                        .HasForeignKey("DepartmentDepartemntId");
                });

            modelBuilder.Entity("HoneyProductSupplier", b =>
                {
                    b.HasOne("DBExam.Classes.HoneyProduct", null)
                        .WithMany()
                        .HasForeignKey("HoneyProductsHoneyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBExam.Classes.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SupplierListSupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DBExam.Classes.Department", b =>
                {
                    b.Navigation("HoneyProducts");

                    b.Navigation("Suppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
