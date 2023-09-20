using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suivi_des_drones.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajoutIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drone",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drone", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Drone_HealthStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "HealthStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIncident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDrone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PathFichier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Raison = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incident_Drone_IdDrone",
                        column: x => x.IdDrone,
                        principalTable: "Drone",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drone_StatusId",
                table: "Drone",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IdDrone",
                table: "Incident",
                column: "IdDrone",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Drone");

            migrationBuilder.DropTable(
                name: "HealthStatus");
        }
    }
}
