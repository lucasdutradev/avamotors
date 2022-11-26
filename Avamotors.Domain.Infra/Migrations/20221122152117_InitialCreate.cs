using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avamotors.Domain.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    NameLastName = table.Column<string>(name: "Name_LastName", type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR", maxLength: 11, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR", maxLength: 155, nullable: false),
                    Sex = table.Column<string>(type: "NVARCHAR", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    NameLastName = table.Column<string>(name: "Name_LastName", type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR", maxLength: 155, nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR", maxLength: 11, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR", maxLength: 80, nullable: false),
                    Km = table.Column<double>(type: "DECIMAL", precision: 2, scale: 2, nullable: false),
                    Year = table.Column<string>(type: "NVARCHAR", maxLength: 4, nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "LONGTEXT", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Seller_Id",
                        column: x => x.Id,
                        principalTable: "Seller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    PriceInThisDay = table.Column<decimal>(type: "DECIMAL", precision: 2, scale: 2, nullable: false),
                    FilledDate = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Availability_Car_Id",
                        column: x => x.Id,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Availability_Client_Id",
                        column: x => x.Id,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Email",
                table: "Client",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_Email",
                table: "Seller",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
