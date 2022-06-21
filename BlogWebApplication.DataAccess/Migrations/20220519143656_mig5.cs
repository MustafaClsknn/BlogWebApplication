using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.DataAccess.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WriterStatus",
                table: "Writers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "ContactStatus",
                table: "Contacts",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CommentStatus",
                table: "Comments",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "CategoryStatus",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "BlogStatus",
                table: "Blogs",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "AboutStatus",
                table: "Abouts",
                newName: "IsActive");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Writers",
                newName: "WriterStatus");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Contacts",
                newName: "ContactStatus");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Comments",
                newName: "CommentStatus");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Categories",
                newName: "CategoryStatus");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Blogs",
                newName: "BlogStatus");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Abouts",
                newName: "AboutStatus");
        }
    }
}
