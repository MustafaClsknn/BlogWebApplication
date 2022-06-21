using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Dto.Request;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    [Authorize(Roles ="Admin,Writer")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public Contact contact;
        public bool success;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var comments = await _contactService.GetAllAsyncDto();
            return View(comments);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ContactAdd()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ContactAdd(AddContactRequest contact)
        {
            if (ModelState.IsValid)
            {
                success = await _contactService.AddAsyncDto(contact);
                if (success)
                {
                   return RedirectToAction("Index","Blog");
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            success = await _contactService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde silindi !", success = true });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ContactDetail(int id)
        {
            var contact = await _contactService.GetByID(id);
            return View(contact);
        }
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            success = _contactService.Update(contact);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde güncellendi !", success = true });
            }
            return View();
        }
        [HttpGet]
        public IActionResult ContactUs() 
        {
            return View();
        }
    }
}
