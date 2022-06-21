using AutoMapper;
using BlogWebApplication.Dto.Request;
using BlogWebApplication.Dto.Response;
using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Business.MapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Blog, BlogListResponse>();
            CreateMap<AddBlogRequest, Blog>();
            CreateMap<UpdateBlogRequest, Blog>();
            CreateMap<Blog, UpdateBlogRequest>();

            CreateMap<Category, CategoryListResponse>();
            CreateMap<AddCategoryRequest, Category>();

            CreateMap<Comment, CommentListResponse>();
            CreateMap<CommentListResponse, Comment>();
            CreateMap<AddCommentRequest, Comment>();

            CreateMap<Writer, WriterListResponse>();
            CreateMap<AddWriterRequest, Writer>();

            CreateMap<Contact, ContactListResponse>();
            CreateMap<AddContactRequest, Contact>();

            CreateMap<User, UserListResponse>();
            CreateMap<AddUserRequest, User>();
            CreateMap<UserLoginRequest, User>();
        }
    }
}
