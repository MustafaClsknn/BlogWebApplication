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
    public class EFCategoryRepository : ICategoryRepository
    {
        private BlogDbContext _dbContext;
        private EntityEntry entityEntry;
        private Category category;
        bool success = false;

        public EFCategoryRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Category category)
        {
            category.CreateDate = DateTime.Now;
            entityEntry = await _dbContext.Categories.AddAsync(category);
            success = entityEntry.State == EntityState.Added;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            category = await _dbContext.Categories.FindAsync(id);
            entityEntry = _dbContext.Categories.Remove(category);
            success = entityEntry.State == EntityState.Deleted;
            _dbContext.SaveChanges();
            return success;
        }

        public IList<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            var categories = await _dbContext.Categories.Where(x => x.IsDeleted == false).ToListAsync();
            return categories;
        }

        public async Task<Category> GetByID(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            category = await _dbContext.Categories.FindAsync(id);
            category.IsDeleted = true;
            entityEntry = _dbContext.Update(category);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

        public bool Update(Category category)
        {
            category.ModifiedDate = DateTime.Now;
            entityEntry = _dbContext.Categories.Update(category);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

    }
}
