using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Dto.Request;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        bool success;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Writer")]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetAllAsyncDto();
            return View(categories);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CategoryAdd() 
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CategoryAdd(AddCategoryRequest category)
        {
            if (ModelState.IsValid)
            {
                success = await _categoryService.AddAsyncDto(category);
                if (success)
                {
                    return RedirectToAction("CategoryList","Category");
                }
            }
            ModelState.AddModelError("CategoryAdd","Kategori eklenirken bir hata oluştu!");
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id) 
        {
            success = await _categoryService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde silindi !", success = true });
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id) 
        {
            var category = await _categoryService.GetByID(id);
            return View(category);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Category category)
        {
            success = _categoryService.Update(category);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde güncellendi !", success = true });
            }
            return View();
        }

    }
}
