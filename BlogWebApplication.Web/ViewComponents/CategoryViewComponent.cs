using BlogWebApplication.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApplication.Web.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
    }
}
