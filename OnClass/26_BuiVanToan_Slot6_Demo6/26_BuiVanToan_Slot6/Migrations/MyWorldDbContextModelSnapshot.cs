﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _26_BuiVanToan_Slot6.Data.Entities;

#nullable disable

namespace _26_BuiVanToan_Slot6.Migrations
{
    [DbContext(typeof(MyWorldDbContext))]
    partial class MyWorldDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("_26_BuiVanToan_Slot6.Data.Entities.Gadgets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gadgets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Samsung",
                            Cost = 12000m,
                            ProductName = "Samsung Galaxy",
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Apple",
                            Cost = 13000m,
                            ProductName = "Iphone",
                            Type = "Mobile"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "IBM",
                            Cost = 34999m,
                            ProductName = "IBM Thinkpad",
                            Type = "Laptop"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "HP",
                            Cost = 21000m,
                            ProductName = "HP ProBook",
                            Type = "Laptop"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Nokia",
                            Cost = 11000m,
                            ProductName = "Nokia 9222",
                            Type = "Mobile"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
