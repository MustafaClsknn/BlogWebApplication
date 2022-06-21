using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Dto.Request
{
    public class UserLoginRequest
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        public string UserMail { get; set; }
        public string Role { get; set; }

    }
}
