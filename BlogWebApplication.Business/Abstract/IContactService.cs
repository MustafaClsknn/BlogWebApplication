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
    public interface IContactService : IService<Contact>
    {
        Task<bool> AddAsyncDto(AddContactRequest contact);
        Task<IList<ContactListResponse>> GetAllAsyncDto();
    }
}
