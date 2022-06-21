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
    public class WriterService : IWriterService
    {
        private readonly IWriterRepository _writerRepository;
        private readonly IMapper _mapper;
        public WriterService(IWriterRepository writerRepository, IMapper mapper)
        {
            _writerRepository = writerRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(Writer writer)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(writer.WriterPassword);
            writer.WriterPassword = passwordHash;
            return await _writerRepository.AddAsync(writer);
        }

        public async Task<bool> AddAsyncDto(AddWriterRequest writer)
        {
            var value = _mapper.Map<Writer>(writer);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(value.WriterPassword);
            value.WriterPassword = passwordHash;
            return await _writerRepository.AddAsync(value);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _writerRepository.DeleteAsync(id);
        }

        public async Task<IList<Writer>> GetAllAsync()
        {
            return await _writerRepository.GetAllAsync();
        }
        public async Task<IList<WriterListResponse>> GetAllAsyncDto()
        {
            var writers = await _writerRepository.GetAllAsync();
            var values = _mapper.Map<IList<WriterListResponse>>(writers);
            return values;
        }

        public async Task<Writer> GetByID(int id)
        {
            return await _writerRepository.GetByID(id);
        }

        public Writer GetWriter(string userName)
        {
            return _writerRepository.GetWriterByUserName(userName);
        }

        public IList<Writer> GetWriters()
        {
            return _writerRepository.GetAll();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _writerRepository.SoftDeleteAsync(id);
        }

        public bool Update(Writer writer)
        {
            return _writerRepository.Update(writer);
        }
        public int GetWriterID(string mail) 
        {
            return _writerRepository.GetWriterID(mail);
        }
    }
}
