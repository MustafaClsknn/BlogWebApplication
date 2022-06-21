using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogWebApplication.DataAccess.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogModifiedDate",
                table: "Blogs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "BlogCreateDate",
                table: "Blogs",
                newName: "CreateDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Writers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Writers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Blogs",
                newName: "BlogModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Blogs",
                newName: "BlogCreateDate");
        }
    }
}
