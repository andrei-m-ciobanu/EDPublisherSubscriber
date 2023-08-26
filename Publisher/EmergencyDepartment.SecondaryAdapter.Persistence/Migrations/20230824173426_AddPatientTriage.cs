using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientTriage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TriageLevel",
                table: "Patients",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TriageLevel",
                table: "Patients");
        }
    }
}
