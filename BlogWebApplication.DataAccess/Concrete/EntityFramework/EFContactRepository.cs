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
    public class EFContactRepository : IContactRepository
    {
        public BlogDbContext _dbContext;
        private EntityEntry entityEntry;
        private Contact contact;
        bool success = false;
        public EFContactRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(Contact contact)
        {
            contact.ContactDate = DateTime.Now;
            contact.CreateDate = DateTime.Now;
            entityEntry = await _dbContext.Contacts.AddAsync(contact);
            success = entityEntry.State == EntityState.Added;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            contact = await _dbContext.Contacts.FindAsync(id);
            entityEntry = _dbContext.Contacts.Remove(contact);
            success = entityEntry.State == EntityState.Deleted;
            _dbContext.SaveChanges();
            return success;
        }

        public async Task<IList<Contact>> GetAllAsync()
        {
            var contacts = await _dbContext.Contacts.Where(x => x.IsDeleted == false).ToListAsync();
            return contacts;
        }

        public async Task<Contact> GetByID(int id)
        {
            return _dbContext.Contacts.Where(x => x.ContactID == id).FirstOrDefault();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            contact = await _dbContext.Contacts.FindAsync(id);
            contact.IsDeleted = true;
            contact.ModifiedDate = DateTime.Now;
            entityEntry = _dbContext.Update(contact);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

        public bool Update(Contact contact)
        {
            contact.ModifiedDate = DateTime.Now;
            entityEntry = _dbContext.Contacts.Update(contact);
            success = entityEntry.State == EntityState.Modified;
            _dbContext.SaveChanges();
            return success;
        }

    }
}
