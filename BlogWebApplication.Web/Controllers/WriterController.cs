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
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IUserService _userService;
        User user = new User();
        bool success;
        bool success2;
        public WriterController(IWriterService writerService,IUserService userService)
        {
            _writerService = writerService;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var writers = await _writerService.GetAllAsyncDto();
            return View(writers);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult WriterAdd()
        {
            ViewBag.Genders = GetGenders();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> WriterAdd(AddWriterRequest writer,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string image = Path.GetExtension(file.FileName);
                    string imageName = Guid.NewGuid() + image;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    user.ImageURL = imageName;
                    writer.WriterImage = imageName;
                }
                user.BirthDate = writer.WriterBirthDate;
                user.UserGender = writer.WriterGender;
                user.UserName = writer.WriterUserName;
                user.FullName = writer.WriterFullName;
                user.UserAbout = writer.WriterAbout;
                user.UserMail = writer.WriterMail;
                user.Password = writer.WriterPassword;
                user.Role = "Writer";
                success = await _writerService.AddAsyncDto(writer);
                success2 = await _userService.AddAsync(user);
                if (success)
                {
                    return RedirectToAction("WriterList","Writer");
                }
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> WriterList()
        {
            var writers = await _writerService.GetAllAsyncDto();
            return View(writers);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            success = await _writerService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde silindi !", success = true });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Genders = GetGenders();
            var category = await _writerService.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Writer writer,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string image = Path.GetExtension(file.FileName);
                    string imageName = Guid.NewGuid() + image;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                    writer.WriterImage = imageName;
                }
                success = _writerService.Update(writer);
                if (success)
                {
                    return RedirectToAction("WriterList", "Writer");
                }
                ModelState.AddModelError("Edit", "Yazar Güncellenemedi!");
            }
            
            return View();
        }
        [HttpGet]
        public IActionResult WriterDetail() 
        {
            string userName = HttpContext.Session.GetString("WriterMail");
            var writer = _writerService.GetWriter(userName);
            return View(writer);
        }
        [HttpPost]
        public async Task<IActionResult> WriterDetail(Writer writer, IFormFile file) 
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string image = Path.GetExtension(file.FileName);
                    string imageName = Guid.NewGuid() + image;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    writer.WriterImage = imageName;
                }

                success = _writerService.Update(writer);
                if (success)
                {
                    return RedirectToAction("WriterList", "Writer");
                }

            }
            return View();
        }
        public List<SelectListItem> GetGenders()
        {
            var genders = new List<SelectListItem>();
            genders.Add(new SelectListItem { Text = "Erkek", Value = "Erkek" });
            genders.Add(new SelectListItem { Text = "Kadın", Value = "Kadın" });
            return genders;
        }
    }
}
