using BlogWebApplication.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApplication.Web.ViewComponents
{
    public class WriterViewComponent: ViewComponent
    {
        IWriterService _writerService;
        public WriterViewComponent(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IViewComponentResult Invoke() 
        {
            var writers = _writerService.GetWriters();
            return View(writers);
        }
    }
}
