﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _26_BuiVanToan_BusinessObject;

#nullable disable

namespace _26_BuiVanToan_BusinessObject.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240118073520_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_26_BuiVanToan_BusinessObject.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Condiments"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Confections"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Dairy Products"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Grains/Cereals"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Meat/Poultry"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Produce"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Seafood"
                        });
                });

            modelBuilder.Entity("_26_BuiVanToan_BusinessObject.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInstock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductName = "Smartphone",
                            UnitPrice = 499m,
                            UnitsInstock = 100
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ProductName = "T-Shirt",
                            UnitPrice = 19m,
                            UnitsInstock = 200
                        });
                });

            modelBuilder.Entity("_26_BuiVanToan_BusinessObject.Product", b =>
                {
                    b.HasOne("_26_BuiVanToan_BusinessObject.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("_26_BuiVanToan_BusinessObject.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
