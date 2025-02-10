using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedComplaintTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.InsertData(
                table: "ComplaintTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Networking" },
                    { "10", "IT Consulting" },
                    { "2", "Software Development" },
                    { "3", "Database Administration" },
                    { "4", "Cybersecurity" },
                    { "5", "Hardware Repairs" },
                    { "6", "Technical Support" },
                    { "7", "Networking" },
                    { "8", "Software Development" },
                    { "9", "System Analysis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "ComplaintTypes",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "CurrentComplaints", "Expertise", "FullName", "IsAvailable" },
                values: new object[,]
                {
                    { "1", null, null, null, null },
                    { "10", null, null, null, null },
                    { "2", null, null, null, null },
                    { "3", null, null, null, null },
                    { "4", null, null, null, null },
                    { "5", null, null, null, null },
                    { "6", null, null, null, null },
                    { "7", null, null, null, null },
                    { "8", null, null, null, null },
                    { "9", null, null, null, null }
                });
        }
    }
}
