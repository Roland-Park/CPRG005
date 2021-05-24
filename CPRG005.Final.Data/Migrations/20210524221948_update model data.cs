using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPRG005.Final.Data.Migrations
{
    public partial class updatemodeldata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "City", "FirstName", "LastName", "Phone" },
                values: new object[] { 1, "Phoenix", "John", "Doe", "555-545-1212" });

            migrationBuilder.UpdateData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StandardRateAmount",
                value: 25.50m);

            migrationBuilder.UpdateData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "StandardRateAmount" },
                values: new object[] { "Weekly", 145.50m });

            migrationBuilder.UpdateData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "StandardRateAmount" },
                values: new object[] { "Monthly", 500.00m });

            migrationBuilder.InsertData(
                table: "LeaseTypes",
                columns: new[] { "Id", "Name", "StandardRateAmount" },
                values: new object[] { 4, "Yearly", 5000.00m });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Inland Lake" },
                    { 2, "San Diego" }
                });

            migrationBuilder.InsertData(
                table: "Authorizations",
                columns: new[] { "Id", "CustomerId", "Password", "UserName" },
                values: new object[] { 1, 1, "10000.z2GCnoFXWCmurPJfIBlFZg==.6m4/OO/bkctGxXSjFJt+fdVRTHvh+LVVb4aVM+WF8zk=", "jdoe" });

            migrationBuilder.InsertData(
                table: "Docks",
                columns: new[] { "Id", "HasElectricService", "HasWaterService", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, true, true, 1, "Dock A" },
                    { 2, false, true, 1, "Dock B" },
                    { 3, false, false, 1, "Dock C" }
                });

            migrationBuilder.InsertData(
                table: "Slips",
                columns: new[] { "Id", "DockId", "Length", "Width" },
                values: new object[,]
                {
                    { 1, 1, 16, 8 },
                    { 103, 2, 26, 10 },
                    { 102, 2, 26, 10 },
                    { 101, 2, 26, 10 },
                    { 100, 2, 24, 10 },
                    { 99, 2, 24, 10 },
                    { 98, 2, 24, 10 },
                    { 97, 2, 24, 10 },
                    { 96, 2, 24, 10 },
                    { 95, 2, 24, 10 },
                    { 94, 2, 24, 10 },
                    { 93, 2, 24, 10 },
                    { 92, 2, 24, 10 },
                    { 91, 2, 24, 10 },
                    { 90, 2, 22, 10 },
                    { 89, 2, 22, 10 },
                    { 88, 2, 22, 10 },
                    { 87, 2, 22, 10 },
                    { 73, 2, 20, 8 },
                    { 74, 2, 20, 8 },
                    { 75, 2, 20, 8 },
                    { 76, 2, 20, 8 },
                    { 77, 2, 20, 8 },
                    { 78, 2, 20, 8 },
                    { 104, 2, 26, 10 },
                    { 79, 2, 20, 8 },
                    { 81, 2, 22, 10 },
                    { 82, 2, 22, 10 },
                    { 83, 2, 22, 10 },
                    { 84, 2, 22, 10 },
                    { 85, 2, 22, 10 },
                    { 86, 2, 22, 10 },
                    { 80, 2, 20, 8 },
                    { 72, 2, 20, 8 },
                    { 105, 2, 26, 10 },
                    { 107, 2, 26, 10 },
                    { 138, 3, 28, 10 },
                    { 137, 3, 28, 10 },
                    { 136, 3, 28, 10 },
                    { 135, 3, 28, 10 },
                    { 134, 3, 28, 10 },
                    { 133, 3, 28, 10 }
                });

            migrationBuilder.InsertData(
                table: "Slips",
                columns: new[] { "Id", "DockId", "Length", "Width" },
                values: new object[,]
                {
                    { 132, 3, 28, 10 },
                    { 131, 3, 28, 10 },
                    { 130, 3, 24, 10 },
                    { 129, 3, 24, 10 },
                    { 128, 3, 24, 10 },
                    { 127, 3, 24, 10 },
                    { 126, 3, 24, 10 },
                    { 125, 3, 24, 10 },
                    { 124, 3, 24, 10 },
                    { 123, 3, 24, 10 },
                    { 122, 3, 24, 10 },
                    { 108, 2, 26, 10 },
                    { 109, 2, 26, 10 },
                    { 110, 2, 26, 10 },
                    { 111, 3, 22, 10 },
                    { 112, 3, 22, 10 },
                    { 113, 3, 22, 10 },
                    { 106, 2, 26, 10 },
                    { 114, 3, 22, 10 },
                    { 116, 3, 22, 10 },
                    { 117, 3, 22, 10 },
                    { 118, 3, 22, 10 },
                    { 119, 3, 22, 10 },
                    { 120, 3, 22, 10 },
                    { 121, 3, 24, 10 },
                    { 115, 3, 22, 10 },
                    { 71, 2, 20, 8 },
                    { 70, 2, 18, 8 },
                    { 69, 2, 18, 8 },
                    { 32, 1, 22, 10 },
                    { 31, 1, 22, 10 },
                    { 30, 1, 20, 8 },
                    { 29, 1, 20, 8 },
                    { 28, 1, 20, 8 },
                    { 27, 1, 20, 8 },
                    { 26, 1, 20, 8 },
                    { 25, 1, 20, 8 },
                    { 24, 1, 20, 8 },
                    { 23, 1, 20, 8 },
                    { 22, 1, 20, 8 },
                    { 21, 1, 20, 8 },
                    { 20, 1, 18, 8 }
                });

            migrationBuilder.InsertData(
                table: "Slips",
                columns: new[] { "Id", "DockId", "Length", "Width" },
                values: new object[,]
                {
                    { 19, 1, 18, 8 },
                    { 18, 1, 18, 8 },
                    { 17, 1, 18, 8 },
                    { 16, 1, 18, 8 },
                    { 2, 1, 16, 8 },
                    { 3, 1, 16, 8 },
                    { 4, 1, 16, 8 },
                    { 5, 1, 16, 8 },
                    { 6, 1, 16, 8 },
                    { 7, 1, 16, 8 },
                    { 33, 1, 22, 10 },
                    { 8, 1, 16, 8 },
                    { 10, 1, 16, 8 },
                    { 11, 1, 18, 8 },
                    { 12, 1, 18, 8 },
                    { 13, 1, 18, 8 },
                    { 14, 1, 18, 8 },
                    { 15, 1, 18, 8 },
                    { 9, 1, 16, 8 },
                    { 34, 1, 22, 10 },
                    { 35, 1, 22, 10 },
                    { 36, 1, 22, 10 },
                    { 55, 2, 16, 8 },
                    { 56, 2, 16, 8 },
                    { 57, 2, 16, 8 },
                    { 58, 2, 16, 8 },
                    { 59, 2, 16, 8 },
                    { 60, 2, 16, 8 },
                    { 54, 2, 16, 8 },
                    { 61, 2, 18, 8 },
                    { 63, 2, 18, 8 },
                    { 64, 2, 18, 8 },
                    { 65, 2, 18, 8 },
                    { 66, 2, 18, 8 },
                    { 67, 2, 18, 8 },
                    { 68, 2, 18, 8 },
                    { 62, 2, 18, 8 },
                    { 139, 3, 28, 10 },
                    { 53, 2, 16, 8 },
                    { 51, 2, 16, 8 },
                    { 37, 1, 22, 10 },
                    { 38, 1, 22, 10 }
                });

            migrationBuilder.InsertData(
                table: "Slips",
                columns: new[] { "Id", "DockId", "Length", "Width" },
                values: new object[,]
                {
                    { 39, 1, 22, 10 },
                    { 40, 1, 22, 10 },
                    { 41, 1, 24, 10 },
                    { 42, 1, 24, 10 },
                    { 52, 2, 16, 8 },
                    { 43, 1, 24, 10 },
                    { 45, 1, 24, 10 },
                    { 46, 1, 24, 10 },
                    { 47, 1, 24, 10 },
                    { 48, 1, 24, 10 },
                    { 49, 1, 24, 10 },
                    { 50, 1, 24, 10 },
                    { 44, 1, 24, 10 },
                    { 140, 3, 28, 10 }
                });

            migrationBuilder.InsertData(
                table: "Leases",
                columns: new[] { "Id", "CustomerId", "EndDate", "LeaseTypeId", "SlipId", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2008, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, new DateTime(2007, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorizations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leases",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Docks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Docks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slips",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Docks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "StandardRateAmount",
                value: 20.00m);

            migrationBuilder.UpdateData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "StandardRateAmount" },
                values: new object[] { "Monthly", 200.00m });

            migrationBuilder.UpdateData(
                table: "LeaseTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "StandardRateAmount" },
                values: new object[] { "Yearly", 2000.00m });
        }
    }
}
