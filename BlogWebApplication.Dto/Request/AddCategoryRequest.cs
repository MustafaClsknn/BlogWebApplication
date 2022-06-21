using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Dto.Request
{
    public class AddCategoryRequest
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
