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
    public interface IBlogService : IService<Blog>
    {
        Task<IList<BlogListResponse>> GetAllAsyncDto(int id);
        Task<IList<BlogListResponse>> GetAllAsyncDto();
        Task<bool> AddAsyncDto(AddBlogRequest blog);
        bool UpdateDto(UpdateBlogRequest blog);
        Task<UpdateBlogRequest> GetByIDDto(int id);
    }
}
