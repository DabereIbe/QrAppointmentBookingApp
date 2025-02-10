using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingComplaintFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Complaints",
                newName: "LoggedAt");

            migrationBuilder.AddColumn<int>(
                name: "ComplaintLimit",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentComplaints",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AssignedStaffId",
                table: "Complaints",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AssignedStaffId1",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AssignedStaffId1",
                table: "Complaints",
                column: "AssignedStaffId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Staff_AssignedStaffId1",
                table: "Complaints",
                column: "AssignedStaffId1",
                principalTable: "Staff",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Staff_AssignedStaffId1",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AssignedStaffId1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintLimit",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "CurrentComplaints",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AssignedStaffId1",
                table: "Complaints");

            migrationBuilder.RenameColumn(
                name: "LoggedAt",
                table: "Complaints",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedStaffId",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Complaints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
