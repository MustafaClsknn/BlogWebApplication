using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Context
{
    public class BlogDbContext : DbContext
    {

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasOne(b => b.Category)
                                       .WithMany(c => c.Blogs)
                                       .HasForeignKey(b => b.CategoryID)
                                       .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Blog>().HasMany(b => b.Comments)
                                       .WithOne(c => c.Blog)
                                       .HasForeignKey(b => b.BlogID)
                                       .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Blog>().HasOne(b => b.Writer)
                                       .WithMany(w => w.Blogs)
                                       .HasForeignKey(b => b.WriterID)
                                       .OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(modelBuilder);
        }
    }

}
