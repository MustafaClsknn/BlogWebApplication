using BlogWebApplicationEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplicationEntities.Concrete
{
    public class Contact : IEntity
    {
        public int ContactID { get; set; }
        public string ContactUserName { get; set; }
        public string ContactMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime? ContactDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
