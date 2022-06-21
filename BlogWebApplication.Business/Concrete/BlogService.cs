using AutoMapper;
using BlogWebApplication.Business.Abstract;
using BlogWebApplication.DataAccess.Abstract;
using BlogWebApplication.Dto.Request;
using BlogWebApplication.Dto.Response;
using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Business.Concrete
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(Blog blog)
        {
            return await _blogRepository.AddAsync(blog);
        }

        public async Task<bool> AddAsyncDto(AddBlogRequest blog)
        {
            var value = _mapper.Map<Blog>(blog);
            return await _blogRepository.AddAsync(value);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _blogRepository.DeleteAsync(id);
        }

        public async Task<IList<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<IList<BlogListResponse>> GetAllAsyncDto(int id)
        {
            var values = await _blogRepository.GetAllAsyncByWriterID(id);
            var blogs = _mapper.Map<IList<BlogListResponse>>(values);
            return blogs;
        }
        public async Task<IList<BlogListResponse>> GetAllAsyncDto()
        {
            var values = await _blogRepository.GetAllAsync();
            var blogs = _mapper.Map<IList<BlogListResponse>>(values);
            return blogs;
        }

        public async Task<Blog> GetByID(int id)
        {
            return await _blogRepository.GetByID(id);
        }

        public async Task<UpdateBlogRequest> GetByIDDto(int id)
        {
            var value = await _blogRepository.GetByID(id);
            var blog = _mapper.Map<UpdateBlogRequest>(value);
            return blog;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _blogRepository.SoftDeleteAsync(id);
        }

        public bool Update(Blog blog)
        {
            return _blogRepository.Update(blog);
        }

        public bool UpdateDto(UpdateBlogRequest blog)
        {
            var value = _mapper.Map<Blog>(blog);
            return _blogRepository.Update(value);
        }

    }
}
