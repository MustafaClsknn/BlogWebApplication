using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckMailUserName(string userName, string mail);
        int GetUserID(string mail);
    }
}
