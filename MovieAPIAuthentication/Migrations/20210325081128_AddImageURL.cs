using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPIAuthentication.Migrations
{
    public partial class AddImageURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Image_URL",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropColumn(
                name: "Image_URL",
                table: "Movies");

        
        }
    }
}
