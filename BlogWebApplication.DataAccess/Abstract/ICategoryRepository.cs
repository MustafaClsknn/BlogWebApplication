using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IList<Category> GetAll();
    }
}
