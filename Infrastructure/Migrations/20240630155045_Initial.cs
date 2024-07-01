using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactAddresses_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Email", "FirstName", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2371), null, "Friend from college", "john.doe@example.com", "John", "Doe", "555-1234", new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2374) },
                    { 2, new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2378), null, "Co-worker at TechCorp", "jane.smith@example.com", "Jane", "Smith", "555-5678", new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2379) },
                    { 3, new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2380), null, "Neighbor", "michael.johnson@example.com", "Michael", "Johnson", "555-8765", new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2381) }
                });

            migrationBuilder.InsertData(
                table: "ContactAddresses",
                columns: new[] { "Id", "ContactId", "CreatedAt", "Latitude", "Longitude", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2974), 51.4966656, -0.1258339, "The Big Ban", new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2975) },
                    { 2, 2, new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2977), -73.988239300000004, 40.748444499999998, "Empire State Building", new DateTime(2024, 6, 30, 15, 50, 45, 105, DateTimeKind.Utc).AddTicks(2977) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddresses_ContactId",
                table: "ContactAddresses",
                column: "ContactId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactAddresses");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
