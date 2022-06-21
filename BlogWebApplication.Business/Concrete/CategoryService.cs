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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> AddAsyncDto(AddCategoryRequest category)
        {
            var value = _mapper.Map<Category>(category);
            return await _categoryRepository.AddAsync(value);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _categoryRepository.DeleteAsync(id);
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }
        public async Task<IList<CategoryListResponse>> GetAllAsyncDto()
        {
            var values =  await _categoryRepository.GetAllAsync();
            var categories = _mapper.Map<IList<CategoryListResponse>>(values);
            return categories;
        }

        public async Task<Category> GetByID(int id)
        {
            return await _categoryRepository.GetByID(id);
        }

        public IList<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _categoryRepository.SoftDeleteAsync(id);
        }

        public bool Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
    }
}
