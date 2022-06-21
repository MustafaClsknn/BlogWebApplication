using BlogWebApplicationEntities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplicationEntities.Concrete
{
    public class Blog : IEntity
    {
        [Required]
        [Key]
        public int BlogID { get; set; }
        [Required(ErrorMessage = "Blog başlığı boş geçilemez !")]
        [MinLength(2 , ErrorMessage = "Blog başlığı 2 karakterden kısa olamaz !")]
        public string BlogTitle { get; set; }
        [Required(ErrorMessage ="Blog içeriği boş geçilemez !")]
        [MinLength(2, ErrorMessage = "Blog içeriği 50 karakterden kısa olamaz. !")]
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Required(ErrorMessage = "Blog kategori kısmı boş geçilemez !")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage = "Blog yazar kısmı boş geçilemez !")]
        public int WriterID { get; set; }
        public Writer Writer { get; set; }
        public bool IsDeleted { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
