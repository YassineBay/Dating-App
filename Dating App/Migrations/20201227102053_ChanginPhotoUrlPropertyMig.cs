using Microsoft.EntityFrameworkCore.Migrations;

namespace Dating_App.Migrations
{
    public partial class ChanginPhotoUrlPropertyMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "urlString",
                table: "Photos",
                newName: "url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Photos",
                newName: "urlString");
        }
    }
}
