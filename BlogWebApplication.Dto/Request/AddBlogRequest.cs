﻿using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Dto.Request
{
    public class AddBlogRequest
    {

        public string BlogTitle { get; set; }
        [Required(ErrorMessage = "Blog içeriği boş geçilemez")]
        [MinLength(2, ErrorMessage = "Blog içeriği 2 karakterden kısa olamaz. !")]
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
    }
}
