using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Abstract
{
    public interface IWriterRepository : IRepository<Writer>
    {
        IList<Writer> GetAll();
        Writer GetWriterByUserName(string userName);
        int GetWriterID(string mail);
    }
}
