using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using BlogWebApplication.Business.Abstract;
using System.Threading.Tasks;
using BlogWebApplication.Dto.Request;
using Microsoft.AspNetCore.Authorization;

namespace BlogWebApplication.Web.Controllers
{
    [Authorize(Roles = "Writer,Client,Admin")]
    public class CommentController : Controller
    {
        ICommentService _commentService;
        IWriterService _writerService;
        public CommentController(ICommentService commentService, IWriterService writerService)
        {
            _commentService = commentService;
            _writerService = writerService;
        }
        [AllowAnonymous]
        public IActionResult CommentPartial() 
        {
            int BlogID = Convert.ToInt32(HttpContext.Session.GetString("BlogID"));
            var comments = _commentService.GetCommentsByBlogID(BlogID);
            return View(comments);
        }
        [HttpPost]
        public async Task<IActionResult> CommentAdd(int blogID, AddCommentRequest comment) 
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            comment.UserID = id;
            comment.BlogID = blogID;
            bool success = await _commentService.AddAsyncDto(comment);
            return RedirectToAction("BlogDetail","Blog",new { id = blogID });
        }
        [HttpGet]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> CommentList() 
        {
            string userName = HttpContext.Session.GetString("WriterMail");
            var writer = _writerService.GetWriter(userName);
            var comments = await _commentService.GetCommentsByWriter(writer.WriterID);
            return View(comments);
        }
        [HttpGet]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> GetDetail(int id) 
        {
            var comment = await _commentService.GetByIDDto(id);
            return View(comment);
        }
    }
}
