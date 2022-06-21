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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(Comment comment)
        {
            return await _commentRepository.AddAsync(comment);
        }
        public async Task<bool> AddAsyncDto(AddCommentRequest comment)
        {
            var value = _mapper.Map<Comment>(comment);
            return await _commentRepository.AddAsync(value);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _commentRepository.DeleteAsync(id);
        }

        public async Task<IList<Comment>> GetAllAsync()
        {
            return await _commentRepository.GetAllAsync();
        }

        public async Task<Comment> GetByID(int id)
        {
            return await _commentRepository.GetByID(id);
        }

        public async Task<IList<Comment>> GetWriters()
        {
            return await _commentRepository.GetAllAsync();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _commentRepository.SoftDeleteAsync(id);
        }

        public bool Update(Comment comment)
        {
            return _commentRepository.Update(comment);
        }
        public IList<Comment> GetCommentsByBlogID(int BlogID)
        {
            return _commentRepository.GetCommentsByBlogID(BlogID);
        }

        public async Task<IList<CommentListResponse>> GetAllAsyncDto()
        {
            var comments = await _commentRepository.GetAllAsync();
            var values = _mapper.Map<IList<CommentListResponse>>(comments);
            return values;
        }

        public async Task<CommentListResponse> GetByIDDto(int id)
        {
            var comment = await _commentRepository.GetByID(id);
            var value = _mapper.Map<CommentListResponse>(comment);
            return value;
        }

        public async Task<IList<CommentListResponse>> GetCommentsByWriter(int writerID)
        {
            var comments = await _commentRepository.GetCommentsByWriterID(writerID);
            var values = _mapper.Map<IList<CommentListResponse>>(comments);
            return values;
        }
    }
}
