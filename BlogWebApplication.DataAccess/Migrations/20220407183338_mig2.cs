using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.DataAccess.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WriterInstagram",
                table: "Writer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WriterLinkedin",
                table: "Writer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WriterTwitter",
                table: "Writer",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterInstagram",
                table: "Writer");

            migrationBuilder.DropColumn(
                name: "WriterLinkedin",
                table: "Writer");

            migrationBuilder.DropColumn(
                name: "WriterTwitter",
                table: "Writer");
        }
    }
}
