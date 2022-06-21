using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<IList<Blog>> GetAllAsyncByWriterID(int id);
    }
}
