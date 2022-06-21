using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Dto.Request;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
namespace BlogWebApplication.Web.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;
        IWriterService _writerService;
        Writer writer = new Writer();
        bool success;
        bool success2;
        bool success3;
        public UserController(IUserService userService, IWriterService writerService)
        {
            _userService = userService;
            _writerService = writerService;
        }
        [HttpGet]
        public IActionResult UserAdd()
        {
            ViewBag.Roles = GetRoles();
            ViewBag.Genders = GetGenders();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserAdd(AddUserRequest user, IFormFile file)
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
                    if (user.Role == "Writer")
                    {
                        writer.WriterImage = imageName;
                    }
                }
                if (user.Role == "Writer")
                {
                    writer.WriterBirthDate = user.BirthDate;
                    writer.WriterGender = user.UserGender;
                    writer.WriterUserName = user.UserName;
                    writer.WriterFullName = user.FullName;
                    writer.WriterAbout = user.UserAbout;
                    writer.WriterMail = user.UserMail;
                    writer.WriterPassword = user.Password;
                    success = await _writerService.AddAsync(writer);
                }
                success2 = await _userService.AddAsyncDto(user);
                if (success2)
                {
                    return RedirectToAction("UserList", "User");
                }
                ModelState.AddModelError("UserAdd", "Kullanıcı eklerken hata ile karşılaşıldı!");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpGet]
        public IActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WriterLogin(UserLoginRequest user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user2 = await _userService.ValidateWriter(user.UserName, user.Password);
                if (user2 != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user2.UserName),
                        new Claim(ClaimTypes.Email, user2.UserMail),
                        new Claim(ClaimTypes.Role, user2.Role),
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    HttpContext.Session.SetString("WriterMail", user2.UserMail);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("BlogList", "Blog");
                    }
                }
                ModelState.AddModelError("login", "kullanıcı adı veya şifre hatalı");

            }
            return View();
        }
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminLogin(UserLoginRequest user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user2 = await _userService.ValidateAdmin(user.UserName, user.Password);
                if (user2 != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user2.UserName),
                        new Claim(ClaimTypes.Email, user2.UserMail),
                        new Claim(ClaimTypes.Role, user2.Role),
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    HttpContext.Session.SetString("AdminMail", user2.UserMail);

                    return RedirectToAction("UserDetail", "User");
                }
                ModelState.AddModelError("login", "kullanıcı adı veya şifre hatalı");

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user2 = await _userService.ValidateUser(user.UserName, user.Password);
                if (user2 != null)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user2.UserName),
                        new Claim(ClaimTypes.Email, user2.UserMail),
                        new Claim(ClaimTypes.Role, user2.Role),
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    string id = Convert.ToString(user2.UserID);
                    HttpContext.Session.SetString("UserID", id);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Blog");
                    }
                }
                ModelState.AddModelError("login", "kullanıcı adı veya şifre hatalı");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Genders = GetGenders();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AddUserRequest user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Client";
                success = await _userService.AddAsyncDto(user);
                return RedirectToAction(nameof(Login));
            }

            return View();
        }
        [HttpGet]
        public IActionResult WriterRegister()
        {
            ViewBag.Genders = GetGenders();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WriterRegister(AddWriterRequest writer)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserMail = writer.WriterMail;
                user.FullName = writer.WriterFullName;
                user.Password = writer.WriterPassword;
                user.PasswordRepeat = writer.WriterPassword;
                user.Role = "Writer";
                success = _userService.CheckMailUserName(writer.WriterUserName, writer.WriterMail);
                if (success)
                {
                    success2 = await _userService.AddAsync(user);
                    success3 = await _writerService.AddAsyncDto(writer);
                    if (success2 && success3)
                    {
                        return RedirectToAction("WriterLogin", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("WriterRegister", "Kullanıcı eklenirken bir hata oluştu !");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("WriterRegister", "Kullanıcı adı veya mail hesabı sistem de kayıtlı !");
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult AdminRegister()
        {
            ViewBag.Genders = GetGenders();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AdminRegister(AddUserRequest user)
        {
            if (ModelState.IsValid)
            {
                user.Role = "Admin";
                success = _userService.CheckMailUserName(user.UserName, user.UserMail);
                if (success)
                {
                    success2 = await _userService.AddAsyncDto(user);
                    if (success2)
                    {
                        return RedirectToAction("AdminLogin", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("AdminRegister", "Kullanıcı eklenirken bir hata oluştu !");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("AdminRegister", "Kullanıcı adı veya mail hesabı sistem de kayıtlı !");
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            string mail = HttpContext.Session.GetString("AdminMail");
            int value = _userService.GetUserIDByMail(mail);
            var user = await _userService.GetByID(value);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {

            var values = await _userService.GetAllAsyncDto();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Blog/Index");
        }
        [HttpGet]
        public async Task<IActionResult> UserDetail()
        {
            ViewBag.Roles = GetRoles();
            ViewBag.Genders = GetGenders();
            string mail = HttpContext.Session.GetString("AdminMail");
            int value = _userService.GetUserIDByMail(mail);
            var user = await _userService.GetByID(value);
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            success = await _userService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde silindi !", success = true });
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
        public List<SelectListItem> GetRoles()
        {
            var roles = new List<SelectListItem>();
            roles.Add(new SelectListItem { Text = "Client", Value = "Client" });
            roles.Add(new SelectListItem { Text = "Admin", Value = "Admin" });
            roles.Add(new SelectListItem { Text = "Writer", Value = "Writer" });
            return roles;
        }
    }
}
