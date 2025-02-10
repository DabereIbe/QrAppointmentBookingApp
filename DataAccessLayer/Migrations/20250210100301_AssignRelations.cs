using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AssignRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Staff_AssignedStaffId1",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AssignedStaffId1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "AssignedStaffId1",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Complaints");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedStaffId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ComplaintTypeId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ComplaintTypes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_AssignedStaffId",
                table: "Complaints",
                column: "AssignedStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_ComplaintTypeId",
                table: "Complaints",
                column: "ComplaintTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_ComplaintTypes_ComplaintTypeId",
                table: "Complaints",
                column: "ComplaintTypeId",
                principalTable: "ComplaintTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_Staff_AssignedStaffId",
                table: "Complaints",
                column: "AssignedStaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_ComplaintTypes_ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_Staff_AssignedStaffId",
                table: "Complaints");

            migrationBuilder.DropTable(
                name: "ComplaintTypes");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_AssignedStaffId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedStaffId",
                table: "Complaints",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AssignedStaffId1",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
