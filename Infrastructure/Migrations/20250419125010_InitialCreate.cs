using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surename = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeOffer = table.Column<string>(type: "text", nullable: false),
                    IsDamaged = table.Column<bool>(type: "boolean", nullable: false),
                    IsImported = table.Column<bool>(type: "boolean", nullable: false),
                    Vin = table.Column<string>(type: "text", nullable: false),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    FirstRegistration = table.Column<string>(type: "text", nullable: false),
                    YearProduction = table.Column<int>(type: "integer", nullable: false),
                    BrandVehicle = table.Column<string>(type: "text", nullable: false),
                    ModelVehicle = table.Column<string>(type: "text", nullable: false),
                    TypeOfFuel = table.Column<string>(type: "text", nullable: false),
                    HorsePower = table.Column<int>(type: "integer", nullable: false),
                    Displacement = table.Column<int>(type: "integer", nullable: false),
                    Doors = table.Column<int>(type: "integer", nullable: false),
                    Transmission = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    Generation = table.Column<string>(type: "text", nullable: false),
                    BodyType = table.Column<string>(type: "text", nullable: false),
                    SourceImages = table.Column<string[]>(type: "text[]", nullable: false),
                    TitleOffer = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
