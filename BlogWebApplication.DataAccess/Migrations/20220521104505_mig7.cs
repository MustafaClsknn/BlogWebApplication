using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.DataAccess.Migrations
{
    public partial class mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentUserName",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Users",
                newName: "UserMail");

            migrationBuilder.AddColumn<string>(
                name: "PasswordRepeat",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAbout",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserID",
                table: "Comments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserID",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PasswordRepeat",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserAbout",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "UserMail",
                table: "Users",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "CommentUserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
