using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.DataAccess.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Category_CategoryID",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Writer_WriterID",
                table: "Blog");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Blog_BlogID",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writer",
                table: "Writer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blog",
                table: "Blog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_About",
                table: "About");

            migrationBuilder.RenameTable(
                name: "Writer",
                newName: "Writers");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Blog",
                newName: "Blogs");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.RenameTable(
                name: "About",
                newName: "Abouts");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BlogID",
                table: "Comments",
                newName: "IX_Comments_BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_WriterID",
                table: "Blogs",
                newName: "IX_Blogs_WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Blog_CategoryID",
                table: "Blogs",
                newName: "IX_Blogs_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writers",
                table: "Writers",
                column: "WriterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ContactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs",
                column: "BlogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts",
                column: "AboutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Categories_CategoryID",
                table: "Blogs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments",
                column: "BlogID",
                principalTable: "Blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Categories_CategoryID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Writers_WriterID",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogID",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Writers",
                table: "Writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Blogs",
                table: "Blogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Abouts",
                table: "Abouts");

            migrationBuilder.RenameTable(
                name: "Writers",
                newName: "Writer");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Blogs",
                newName: "Blog");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.RenameTable(
                name: "Abouts",
                newName: "About");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogID",
                table: "Comment",
                newName: "IX_Comment_BlogID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_WriterID",
                table: "Blog",
                newName: "IX_Blog_WriterID");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_CategoryID",
                table: "Blog",
                newName: "IX_Blog_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Writer",
                table: "Writer",
                column: "WriterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "ContactID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "CommentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blog",
                table: "Blog",
                column: "BlogID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_About",
                table: "About",
                column: "AboutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Category_CategoryID",
                table: "Blog",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Writer_WriterID",
                table: "Blog",
                column: "WriterID",
                principalTable: "Writer",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Blog_BlogID",
                table: "Comment",
                column: "BlogID",
                principalTable: "Blog",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
