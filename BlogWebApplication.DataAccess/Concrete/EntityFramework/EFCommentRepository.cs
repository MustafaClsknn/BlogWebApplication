using BlogWebApplication.DataAccess.Abstract;
using BlogWebApplication.DataAccess.Context;
using BlogWebApplicationEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Concrete.EntityFramework
{
    public class EFCommentRepository : ICommentRepository
    {
        public BlogDbContext _dbContext;
        private EntityEntry entityEntry;
        private Comment comment;
        bool success = false;
        public EFCommentRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Comment comment)
        {
            comment.CommentDate = DateTime.Now;
            entityEntry = await _dbContext.Comments.AddAsync(comment);
            success = entityEntry.State == EntityState.Added;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            comment = await _dbContext.Comments.FindAsync(id);
            entityEntry = _dbContext.Comments.Remove(comment);
            success = entityEntry.State == EntityState.Deleted;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<IList<Comment>> GetAllAsync()
        {
            var comments = await _dbContext.Comments.Where(x => x.IsDeleted == false).Include(x=> x.Blog).Include(y=> y.User).ToListAsync();
            return comments;
        }

        public async Task<Comment> GetByID(int id)
        {
            return  _dbContext.Comments.Where(x => x.CommentID == id).Include(x => x.Blog).Include(y => y.User).FirstOrDefault();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            comment = await _dbContext.Comments.FindAsync(id);
            comment.IsDeleted = true;
            entityEntry = _dbContext.Update(comment);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

        public bool Update(Comment comment)
        {

            entityEntry = _dbContext.Comments.Update(comment);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }
        public IList<Comment> GetCommentsByBlogID(int BlogID)
        {
            return _dbContext.Comments.Where(x => x.BlogID == BlogID).Include(y => y.User).ToList();
        }

        public async Task<IList<Comment>> GetCommentsByWriterID(int writerID)
        {
            var blogs = await _dbContext.Blogs.Where(x => x.WriterID == writerID).Include(x=> x.Comments).ThenInclude(x=> x.User).Include(x=> x.Comments).ThenInclude(x=> x.Blog).ToListAsync();
            IList<Comment> comments = new List<Comment>();
            foreach (var item in blogs)
            {
                foreach (var comment in item.Comments )
                {
                    comments.Add(comment);
                }
            }
            return comments;
        }
    }
}
