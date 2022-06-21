using BlogWebApplication.Dto.Request;
using BlogWebApplication.Dto.Response;
using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Business.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        IList<Category> GetCategories();
        Task<bool> AddAsyncDto(AddCategoryRequest category);
        Task<IList<CategoryListResponse>> GetAllAsyncDto();
    }
}
