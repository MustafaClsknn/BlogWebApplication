using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Dto.Request
{
    public class AddUserRequest
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string UserAbout { get; set; }
        public string UserMail { get; set; }
        public string ImageURL { get; set; }
        public string UserGender { get; set; }
        public string Role { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<Comment> Comments { get; set; }
        public bool IsDeleted { get; set; }
    }
}
