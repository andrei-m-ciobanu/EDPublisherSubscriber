using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncounterStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EncounterEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodPressures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Systolic = table.Column<int>(type: "int", nullable: true),
                    Diastolic = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanMeasure = table.Column<bool>(type: "bit", nullable: false),
                    EffectiveDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodPressures_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespiratoryRates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BreathsPerMin = table.Column<double>(type: "float", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespiratoryRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespiratoryRates_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueInCelsius = table.Column<double>(type: "float", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressures_PatientId",
                table: "BloodPressures",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_RespiratoryRates_PatientId",
                table: "RespiratoryRates",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_PatientId",
                table: "Temperatures",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodPressures");

            migrationBuilder.DropTable(
                name: "RespiratoryRates");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
