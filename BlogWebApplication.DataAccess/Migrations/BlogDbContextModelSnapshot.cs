﻿// <auto-generated />
using System;
using BlogWebApplication.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogWebApplication.DataAccess.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    partial class BlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Blog", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogThumbnailImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WriterID")
                        .HasColumnType("int");

                    b.HasKey("BlogID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WriterID");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("BlogID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ContactDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactSubject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordRepeat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Writer", b =>
                {
                    b.Property<int>("WriterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WriterAbout")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WriterBirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WriterFullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterInstagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterLinkedin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterTwitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WriterUserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WriterID");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Blog", b =>
                {
                    b.HasOne("BlogWebApplicationEntities.Concrete.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("BlogWebApplicationEntities.Concrete.Writer", "Writer")
                        .WithMany("Blogs")
                        .HasForeignKey("WriterID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Comment", b =>
                {
                    b.HasOne("BlogWebApplicationEntities.Concrete.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("BlogWebApplicationEntities.Concrete.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Blog", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.User", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("BlogWebApplicationEntities.Concrete.Writer", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
