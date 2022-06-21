using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Dto.Request;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    [Authorize(Roles ="Admin,Writer,Client")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;
        private readonly ICategoryService _categoryService;
        bool success;
        public BlogController(IBlogService blogService, IWriterService writerService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _writerService = writerService;
            _categoryService = categoryService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1, int catId = 0, int writerId = 0)
        {

            var blogsFromService = await _blogService.GetAllAsyncDto();
           // var blogs = catId == 0 ? writerId == 0 ? blogsFromService.ToList() : blogsFromService.Where(x => x.CategoryID == catId).ToList() writerId == 0 ? blogsFromService.Where(x => x.WriterID == catId).ToList() : blogsFromService.Where(x => x.CategoryID == catId).ToList();
            var blogs = blogsFromService.ToList();
            if (catId != 0)
            {
                blogs = blogsFromService.Where(x => x.CategoryID == catId).ToList();
            }
            if (writerId != 0) 
            {
                blogs = blogsFromService.Where(x => x.WriterID == writerId).ToList();
            }
            var blogsPerPage = 6;
            var paginatedBlogs = blogs.OrderByDescending(p => p.BlogID)
                                            .Skip((page - 1) * blogsPerPage)
                                            .Take(blogsPerPage);
            ViewBag.CurrentPage = page;
            ViewBag.Category = catId;
            ViewBag.TotalPages = Math.Ceiling((decimal)blogs.Count / blogsPerPage);

            return View(paginatedBlogs);
        }
        [HttpGet]
        [Authorize(Roles ="Client,Writer,Admin")]
        public async Task<IActionResult> BlogDetail(int id)
        {
            var blog = await _blogService.GetByID(id);
            HttpContext.Session.SetString("BlogID", id.ToString());
            return View(blog);
        }
        [HttpGet]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> BlogAdd()
        {
            ViewBag.SelectedCategories = await GetCategoriesForDropDown();
            //ViewBag.SelectedWriters = await GetWritersForDropDown();
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult> BlogAdd(AddBlogRequest blog, IFormFile[] file)
        {
            string userName = HttpContext.Session.GetString("WriterMail");
            var writer = _writerService.GetWriter(userName);
            blog.WriterID = writer.WriterID;
            if (file != null)
             {
                string imageExtensionThumb = Path.GetExtension(file[0].FileName);
                string imageNameThumb = Guid.NewGuid() + imageExtensionThumb;
                string pathThumb = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageNameThumb}");
                using var streamThumb = new FileStream(pathThumb, FileMode.Create);
                await file[0].CopyToAsync(streamThumb);

                blog.BlogThumbnailImage = imageNameThumb;

                string imageExtension = Path.GetExtension(file[1].FileName);
                string imageName = Guid.NewGuid() + imageExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                using var stream = new FileStream(path, FileMode.Create);
                await file[1].CopyToAsync(stream);

                blog.BlogImage = imageName;
            }
            success = await _blogService.AddAsyncDto(blog);
            if (success)
            {
                return RedirectToAction("BlogList","Blog");
                //return Json(new JsonReturnObject { text = "Kayıt işlemi başarılı !", success = true });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetByIDDto(id);
            ViewBag.SelectedCategories = await GetCategoriesForDropDown();
            ViewBag.SelectedWriters = await GetWritersForDropDown();
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBlogRequest blog, IFormFile[] file)
        {
           if (ModelState.IsValid)
            {
                if (file.Count() == 2)
                {
                    string imageExtensionThumb = Path.GetExtension(file[0].FileName);
                    string imageNameThumb = Guid.NewGuid() + imageExtensionThumb;
                    string pathThumb = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageNameThumb}");
                    using var streamThumb = new FileStream(pathThumb, FileMode.Create);
                    await file[0].CopyToAsync(streamThumb);

                    blog.BlogThumbnailImage = imageNameThumb;

                    string imageExtension = Path.GetExtension(file[1].FileName);
                    string imageName = Guid.NewGuid() + imageExtension;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    using var stream = new FileStream(path, FileMode.Create);
                    await file[1].CopyToAsync(stream);

                    blog.BlogImage = imageName;
                }
                success = _blogService.UpdateDto(blog);
                if (success)
                {
                    return RedirectToAction(nameof(BlogList));
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            success = await _blogService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Silme işlemi Başarılı", success = true });
            }
            return View();
        }
        public async Task<IActionResult> BlogList()
        {
            string mail = HttpContext.Session.GetString("WriterMail");
            int WriterID = _writerService.GetWriterID(mail);
            var blogs = await _blogService.GetAllAsyncDto(WriterID);
            return View(blogs);
        }
        public async Task<List<SelectListItem>> GetWritersForDropDown()
        {

            var selectedWriters = new List<SelectListItem>();
            var items = await _writerService.GetAllAsyncDto();
            foreach (var item in items)
            {
                selectedWriters.Add
                    (
                    new SelectListItem { Text = item.WriterFullName, Value = item.WriterID.ToString() }
                    );
            }
            return selectedWriters;
        }
        public async Task<List<SelectListItem>> GetCategoriesForDropDown()
        {

            var selectedCategories = new List<SelectListItem>();
            var items = await _categoryService.GetAllAsyncDto();
            foreach (var item in items)
            {
                selectedCategories.Add
                    (
                    new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() }
                    );
            }
            return selectedCategories;
        }

    }
}
