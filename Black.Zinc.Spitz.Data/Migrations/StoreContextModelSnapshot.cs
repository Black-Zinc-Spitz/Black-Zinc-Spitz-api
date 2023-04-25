﻿// <auto-generated />
using System;
using Black.Zinc.Spitz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Black.Zinc.Spitz.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Catalog.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Nike",
                            Description = "Ohio State shirt",
                            Name = "Shirt",
                            Price = 29.99m
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Nike",
                            Description = "Ohio State shorts",
                            Name = "Shirt",
                            Price = 44.99m
                        });
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Catalog.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stars")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Orders.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Catalog.Rating", b =>
                {
                    b.HasOne("Black.Zinc.Spitz.Domain.Catalog.Item", null)
                        .WithMany("Ratings")
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Orders.OrderItem", b =>
                {
                    b.HasOne("Black.Zinc.Spitz.Domain.Catalog.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Black.Zinc.Spitz.Domain.Orders.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Catalog.Item", b =>
                {
                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("Black.Zinc.Spitz.Domain.Orders.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
