using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPIAuthentication.Migrations
{
    public partial class nonRequiredPoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Posters_PosterId",
                table: "Movies");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Posters_PosterId",
                table: "Movies",
                column: "PosterId",
                principalTable: "Posters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Posters_PosterId",
                table: "Movies");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Posters_PosterId",
                table: "Movies",
                column: "PosterId",
                principalTable: "Posters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
