using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.DataAccess.Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IList<Comment> GetCommentsByBlogID(int BlogID);
        Task<IList<Comment>> GetCommentsByWriterID(int writerID);
    }
}
