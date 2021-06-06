using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG005.Final.Data.Migrations
{
    public partial class Addsecondloctodefaultslipdataproperly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Docks",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocationId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 21,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 22,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 23,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 24,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 25,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 26,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 27,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 28,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 29,
                column: "DockId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 30,
                column: "DockId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Docks",
                keyColumn: "Id",
                keyValue: 3,
                column: "LocationId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 21,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 22,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 23,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 24,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 25,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 26,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 27,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 28,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 29,
                column: "DockId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 30,
                column: "DockId",
                value: 2);
        }
    }
}
