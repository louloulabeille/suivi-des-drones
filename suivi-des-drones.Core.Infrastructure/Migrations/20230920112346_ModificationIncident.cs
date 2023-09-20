using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace suivi_des_drones.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModificationIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Incident_IdDrone",
                table: "Incident");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IdDrone",
                table: "Incident",
                column: "IdDrone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Incident_IdDrone",
                table: "Incident");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_IdDrone",
                table: "Incident",
                column: "IdDrone",
                unique: true);
        }
    }
}
