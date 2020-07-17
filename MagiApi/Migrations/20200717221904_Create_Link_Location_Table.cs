using Microsoft.EntityFrameworkCore.Migrations;

namespace MagiApi.Migrations
{
    public partial class Create_Link_Location_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EventId",
                table: "Locations",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Events_EventId",
                table: "Locations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Events_EventId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_EventId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Locations");
        }
    }
}
