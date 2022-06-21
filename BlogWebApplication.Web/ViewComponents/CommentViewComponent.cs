using BlogWebApplication.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogWebApplication.Web.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            int BlogID = Convert.ToInt32(HttpContext.Session.GetString("BlogID"));
            var comments = _commentService.GetCommentsByBlogID(BlogID);
            return View(comments);
        }
    }
}
