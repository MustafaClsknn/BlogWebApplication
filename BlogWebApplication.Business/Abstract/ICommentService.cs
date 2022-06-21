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
    public interface ICommentService : IService<Comment>
    {
        IList<Comment> GetCommentsByBlogID(int BlogID);
        Task<IList<CommentListResponse>> GetAllAsyncDto();
        Task<bool> AddAsyncDto(AddCommentRequest comment);
        Task<CommentListResponse> GetByIDDto(int id);
        Task<IList<CommentListResponse>> GetCommentsByWriter(int writerID);
    }
}
