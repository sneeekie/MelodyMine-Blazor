﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(EfDbContext))]
    [Migration("20231122114322_UpdateModels")]
    partial class UpdateModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AddressId"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Postal")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            CardNumber = "4111 1111 1111 1111",
                            City = "Copenhagen",
                            Country = "Denmark",
                            Postal = 2400,
                            Street = "Birkedommervej",
                            StreetNumber = 29
                        },
                        new
                        {
                            AddressId = 2,
                            CardNumber = "4111 1111 1111 1112",
                            City = "Fredericia",
                            Country = "Denmark",
                            Postal = 7000,
                            Street = "Dronningsgade",
                            StreetNumber = 8
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Alternative"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "HipHop"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Pop"
                        },
                        new
                        {
                            GenreId = 4,
                            GenreName = "Christmas"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.OrderProductDetails", b =>
                {
                    b.Property<int>("OrderProductDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderProductDetailsId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("VinylId")
                        .HasColumnType("integer");

                    b.HasKey("OrderProductDetailsId");

                    b.HasIndex("OrderId");

                    b.HasIndex("VinylId");

                    b.ToTable("OrderProductDetails");

                    b.HasData(
                        new
                        {
                            OrderProductDetailsId = 1,
                            OrderId = 1,
                            Price = 127m,
                            Quantity = 0,
                            VinylId = 1
                        },
                        new
                        {
                            OrderProductDetailsId = 2,
                            OrderId = 2,
                            Price = 187m,
                            Quantity = 0,
                            VinylId = 2
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Vinyl", b =>
                {
                    b.Property<int>("VinylId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VinylId"));

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VinylId");

                    b.HasIndex("GenreId");

                    b.ToTable("Vinyls");

                    b.HasData(
                        new
                        {
                            VinylId = 1,
                            Artist = "Ukendt Kunstner",
                            GenreId = 2,
                            ImagePath = "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/i/m/image001_9__2.jpg",
                            Price = 127m,
                            Title = "Dansktop"
                        },
                        new
                        {
                            VinylId = 2,
                            Artist = "Kanye West",
                            GenreId = 2,
                            ImagePath = "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/k/a/kanye-west-2018-ye-compact-disc.jpg",
                            Price = 187m,
                            Title = "Ye"
                        },
                        new
                        {
                            VinylId = 3,
                            Artist = "Radiohead",
                            GenreId = 1,
                            ImagePath = "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/b/f/bfea3555ad38fe476532c5b54f218c09_1.jpg",
                            Price = 227m,
                            Title = "OK Computer"
                        },
                        new
                        {
                            VinylId = 4,
                            Artist = "Frank Ocean",
                            GenreId = 3,
                            ImagePath = "https://best-fit.transforms.svdcdn.com/production/albums/frank-ocean-blond-compressed-0933daea-f052-40e5-85a4-35e07dac73df.jpg?w=469&h=469&q=100&auto=format&fit=crop&dm=1643652677&s=6ef41cb2628eb28d736e27b42635b66e",
                            Price = 777m,
                            Title = "Blonde"
                        },
                        new
                        {
                            VinylId = 5,
                            Artist = "Dean Martin",
                            GenreId = 4,
                            ImagePath = "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/m/o/moby-disc-13-09-2023_10.54.44.png",
                            Price = 127m,
                            Title = "Winter Wonderland"
                        });
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BuyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            AddressId = 1,
                            BuyDate = new DateTime(2023, 11, 22, 11, 43, 22, 155, DateTimeKind.Utc).AddTicks(7230),
                            Email = "john@example.com"
                        },
                        new
                        {
                            OrderId = 2,
                            AddressId = 2,
                            BuyDate = new DateTime(2023, 11, 22, 11, 43, 22, 155, DateTimeKind.Utc).AddTicks(7230),
                            Email = "adrian@example.com"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.OrderProductDetails", b =>
                {
                    b.HasOne("Order", "Order")
                        .WithMany("OrderProductDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Vinyl", "Vinyl")
                        .WithMany()
                        .HasForeignKey("VinylId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Vinyl");
                });

            modelBuilder.Entity("DataLayer.Models.Vinyl", b =>
                {
                    b.HasOne("DataLayer.Models.Genre", "Genre")
                        .WithMany("Vinyls")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("DataLayer.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DataLayer.Models.Genre", b =>
                {
                    b.Navigation("Vinyls");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Navigation("OrderProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
