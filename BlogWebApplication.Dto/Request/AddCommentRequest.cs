using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Dto.Request
{
    public class AddCommentRequest
    {
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
