using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Postal = table.Column<int>(type: "integer", nullable: false),
                    StreetNumber = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    CardNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Vinyls",
                columns: table => new
                {
                    VinylId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Artist = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinyls", x => x.VinylId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VinylGenres",
                columns: table => new
                {
                    VinylId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinylGenres", x => new { x.VinylId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_VinylGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinylGenres_Vinyls_VinylId",
                        column: x => x.VinylId,
                        principalTable: "Vinyls",
                        principalColumn: "VinylId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductDetails",
                columns: table => new
                {
                    OrderProductDetailsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VinylId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductDetails", x => x.OrderProductDetailsId);
                    table.ForeignKey(
                        name: "FK_OrderProductDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProductDetails_Vinyls_VinylId",
                        column: x => x.VinylId,
                        principalTable: "Vinyls",
                        principalColumn: "VinylId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "CardNumber", "City", "Country", "Postal", "Street", "StreetNumber" },
                values: new object[,]
                {
                    { 1, "4111 1111 1111 1111", "Copenhagen", "Denmark", 2400, "Birkedommervej", 29 },
                    { 2, "4111 1111 1111 1112", "Fredericia", "Denmark", 7000, "Dronningsgade", 8 }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Alternative" },
                    { 2, "HipHop" },
                    { 3, "Pop" },
                    { 4, "Christmas" }
                });

            migrationBuilder.InsertData(
                table: "Vinyls",
                columns: new[] { "VinylId", "Artist", "GenreId", "ImagePath", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Ukendt Kunstner", 2, "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/i/m/image001_9__2.jpg", 127m, "Dansktop" },
                    { 2, "Kanye West", 2, "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/k/a/kanye-west-2018-ye-compact-disc.jpg", 187m, "Ye" },
                    { 3, "Radiohead", 1, "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/b/f/bfea3555ad38fe476532c5b54f218c09_1.jpg", 227m, "OK Computer" },
                    { 4, "Frank Ocean", 3, "https://best-fit.transforms.svdcdn.com/production/albums/frank-ocean-blond-compressed-0933daea-f052-40e5-85a4-35e07dac73df.jpg?w=469&h=469&q=100&auto=format&fit=crop&dm=1643652677&s=6ef41cb2628eb28d736e27b42635b66e", 777m, "Blonde" },
                    { 5, "Dean Martin", 4, "https://moby-disc.dk/media/catalog/product/cache/e7dc67195437dd6c7bf40d88e25a85ce/m/o/moby-disc-13-09-2023_10.54.44.png", 127m, "Winter Wonderland" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "AddressId", "BuyDate", "Email" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 11, 22, 8, 8, 49, 509, DateTimeKind.Utc).AddTicks(8340), "john@example.com" },
                    { 2, 2, new DateTime(2023, 11, 22, 8, 8, 49, 509, DateTimeKind.Utc).AddTicks(8340), "adrian@example.com" }
                });

            migrationBuilder.InsertData(
                table: "VinylGenres",
                columns: new[] { "GenreId", "VinylId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "OrderProductDetails",
                columns: new[] { "OrderProductDetailsId", "OrderId", "Price", "Quantity", "VinylId" },
                values: new object[,]
                {
                    { 1, 1, 127m, 0, 1 },
                    { 2, 2, 187m, 0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductDetails_OrderId",
                table: "OrderProductDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductDetails_VinylId",
                table: "OrderProductDetails",
                column: "VinylId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_VinylGenres_GenreId",
                table: "VinylGenres",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProductDetails");

            migrationBuilder.DropTable(
                name: "VinylGenres");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Vinyls");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
