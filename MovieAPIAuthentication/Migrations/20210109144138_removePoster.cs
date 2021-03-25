using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPIAuthentication.Migrations
{
    public partial class removePoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Posters_PosterId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_PosterId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosterId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PosterId",
                table: "Movies",
                column: "PosterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Posters_PosterId",
                table: "Movies",
                column: "PosterId",
                principalTable: "Posters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
