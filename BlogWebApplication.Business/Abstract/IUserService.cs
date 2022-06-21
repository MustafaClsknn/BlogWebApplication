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
    public interface IUserService : IService<User>
    {
        Task<User> ValidateUser(string userName, string password);
        bool CheckMailUserName(string userName,string mail);
        Task<User> ValidateAdmin(string userName, string password);
        Task<User> ValidateWriter(string userName, string password);
        Task<bool> AddAsyncDto(AddUserRequest user);
        Task<IList<UserListResponse>> GetAllAsyncDto();
        int GetUserIDByMail(string mail);
    }
}
