using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Spotlight.SignalR.Migrations
{
    /// <inheritdoc />
    public partial class Message3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Messages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "Messages",
                newName: "ReceiverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Messages",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Messages",
                newName: "Receiver");
        }
    }
}
