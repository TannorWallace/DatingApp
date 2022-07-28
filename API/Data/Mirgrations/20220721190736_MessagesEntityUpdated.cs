using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Mirgrations
{
    public partial class MessagesEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReciepientId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReciepientId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReciepientId",
                table: "Messages");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecipientId",
                table: "Messages",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecipientId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "ReciepientId",
                table: "Messages",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReciepientId",
                table: "Messages",
                column: "ReciepientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReciepientId",
                table: "Messages",
                column: "ReciepientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
