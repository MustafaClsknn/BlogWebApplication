using BlogWebApplicationEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Abstract
{
    public interface IRepository<T> where T : class,IEntity,new()
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByID(int id);
        Task<bool> AddAsync(T t);
        Task<bool> DeleteAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        bool Update(T t);
    }
}
