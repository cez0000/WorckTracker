using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersToActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Activity",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activity_UserId",
                table: "Activity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_AspNetUsers_UserId",
                table: "Activity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_AspNetUsers_UserId",
                table: "Activity");

            migrationBuilder.DropIndex(
                name: "IX_Activity_UserId",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Activity");
        }
    }
}
