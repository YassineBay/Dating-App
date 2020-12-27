using Microsoft.EntityFrameworkCore.Migrations;

namespace Dating_App.Migrations
{
    public partial class ChanginPhotoUrlPropertyMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Photos",
                newName: "Url");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Photos",
                newName: "url");
        }
    }
}
