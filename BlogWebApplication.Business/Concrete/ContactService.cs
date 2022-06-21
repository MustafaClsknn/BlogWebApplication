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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public ContactService(IContactRepository contactRepository,IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(Contact contact)
        {
            return await _contactRepository.AddAsync(contact);
        }

        public async Task<bool> AddAsyncDto(AddContactRequest contact)
        {
            var value = _mapper.Map<Contact>(contact);
            return await _contactRepository.AddAsync(value);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _contactRepository.DeleteAsync(id);
        }

        public async Task<IList<Contact>> GetAllAsync()
        {
            return await _contactRepository.GetAllAsync();
        }
        public async Task<IList<ContactListResponse>> GetAllAsyncDto()
        {
            var values = await _contactRepository.GetAllAsync();
            var contacts = _mapper.Map<IList<ContactListResponse>>(values);
            return contacts;
        }

        public async Task<Contact> GetByID(int id)
        {
            return await _contactRepository.GetByID(id);
        }
        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _contactRepository.SoftDeleteAsync(id);
        }

        public bool Update(Contact contact)
        {
            return _contactRepository.Update(contact);
        }
    }
}
