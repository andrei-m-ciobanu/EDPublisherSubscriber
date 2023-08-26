using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fix_RespiratoryRate_ColumnValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "BreathsPerMin",
                table: "RespiratoryRates",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "BreathsPerMin",
                table: "RespiratoryRates",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
