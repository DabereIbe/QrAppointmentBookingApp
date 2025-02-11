using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditComplaintTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_ComplaintTypes_ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "ComplaintTypeId",
                table: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Complaints");

            migrationBuilder.AddColumn<string>(
                name: "ComplaintTypeId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
