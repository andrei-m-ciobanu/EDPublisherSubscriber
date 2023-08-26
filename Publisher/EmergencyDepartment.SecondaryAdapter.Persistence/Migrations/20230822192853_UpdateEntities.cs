using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyDepartment.SecondaryAdapter.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanMeasure",
                table: "BloodPressures");

            migrationBuilder.AlterColumn<int>(
                name: "Systolic",
                table: "BloodPressures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Diastolic",
                table: "BloodPressures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Systolic",
                table: "BloodPressures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Diastolic",
                table: "BloodPressures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "CanMeasure",
                table: "BloodPressures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
