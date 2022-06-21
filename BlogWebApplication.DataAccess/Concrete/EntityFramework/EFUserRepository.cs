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
    public class EFUserRepository : IUserRepository
    {
        private BlogDbContext _dbContext;
        private EntityEntry entityEntry;
        private User user;
        bool success = false;
        public EFUserRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddAsync(User user)
        {
            user.CreateDate = DateTime.Now;
            entityEntry = await _dbContext.Users.AddAsync(user);
            success = entityEntry.State == EntityState.Added;
            _dbContext.SaveChanges();
            return success;
        }

        public bool CheckMailUserName(string userName, string mail)
        {
            List<User> users = _dbContext.Users.ToList();
            user = users.Where(x => x.UserMail == mail || x.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            user = await _dbContext.Users.FindAsync(id);
            entityEntry = _dbContext.Users.Remove(user);
            success = entityEntry.State == EntityState.Deleted;
            _dbContext.SaveChanges();
            return success;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.Where(x => x.IsDeleted == false).ToList();
        }

        public async Task<IList<User>> GetAllAsync()
        {
            var users = await _dbContext.Users.Where(x=> x.IsDeleted == false).ToListAsync();
            return users;
        }

        public async Task<User> GetByID(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public int GetUserID(string mail)
        {
            return _dbContext.Users.Where(x => x.UserMail == mail).Select(x => x.UserID).FirstOrDefault();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        { 
            user = await _dbContext.Users.FindAsync(id);
            user.IsDeleted = true;
            entityEntry = _dbContext.Update(user);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

        public bool Update(User blog)
        {
            entityEntry = _dbContext.Update(blog);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }
    }
}
