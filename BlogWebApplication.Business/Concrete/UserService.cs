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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(User user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            return await _userRepository.AddAsync(user);
        }
        public async Task<bool> AddAsyncDto(AddUserRequest user)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            var value = _mapper.Map<User>(user);
            return await _userRepository.AddAsync(value);
        }
        public bool CheckMailUserName(string userName, string mail)
        {
            return _userRepository.CheckMailUserName(userName, mail);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<IList<UserListResponse>> GetAllAsyncDto()
        {
            var users = await _userRepository.GetAllAsync();
            var values = _mapper.Map<IList<UserListResponse>>(users);
            return values;
        }

        public async Task<User> GetByID(int id)
        {
            return await _userRepository.GetByID(id);
        }
        public async Task<bool> SoftDeleteAsync(int id)
        {
            return await _userRepository.SoftDeleteAsync(id);
        }

        public bool Update(User category)
        {
            return _userRepository.Update(category);
        }

        public async Task<User> ValidateAdmin(string userName, string password)
        {
            var users = await _userRepository.GetAllAsync();
            User user2 = null;
            foreach (var item in users)
            {
                if (item.UserName == userName && item.Role == "Admin" )
                {
                   
                    bool success = BCrypt.Net.BCrypt.Verify(password, item.Password);
                    if (success)
                    {
                        user2 = item;
                        return user2;
                    }

                }
            }
            return null;
        }

        public async Task<User> ValidateWriter(string userName, string password)
        {
            var users = await _userRepository.GetAllAsync();
            User user2 = null;
            foreach (var item in users)
            {
                if (item.UserName == userName && item.Role == "Writer")
                {
                    bool success = BCrypt.Net.BCrypt.Verify(password, item.Password);
                    if (success)
                    {
                        user2 = item;
                        return user2;
                    }

                }
            }
            return null;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            var users = await _userRepository.GetAllAsync();
            User user2 = null;
            foreach (var item in users)
            {
                if (item.UserName == userName)
                {
                    bool success = BCrypt.Net.BCrypt.Verify(password, item.Password);
                    if (success)
                    {
                        user2 = item;
                        return user2;
                    }

                }
            }
            return null;
        }

        public int GetUserIDByMail(string mail)
        {
            return _userRepository.GetUserID(mail);
        }
    }
}
