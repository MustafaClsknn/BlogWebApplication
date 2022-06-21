using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Dto.Response
{
    public class WriterListResponse
    {
        public int WriterID { get; set; }
        public string WriterUserName { get; set; }
        public string WriterFullName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterTwitter { get; set; }
        public string WriterInstagram { get; set; }
        public string WriterLinkedin { get; set; }
        public string WriterGender { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? WriterBirthDate { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
