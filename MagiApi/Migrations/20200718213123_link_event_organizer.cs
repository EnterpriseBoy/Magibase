using Microsoft.EntityFrameworkCore.Migrations;

namespace MagiApi.Migrations
{
    public partial class link_event_organizer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Organizers_EventId",
                table: "Organizers",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_Events_EventId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_EventId",
                table: "Organizers");
        }
    }
}
