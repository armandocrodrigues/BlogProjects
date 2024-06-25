using BCrypt.Net;
using Blog.Application.InterfacesServices;
using Blog.Domain.Entities;
using Blog.Domain.InterfacesRepositories;
using Blog.Infra.DBContext;
using Blog.Infra.Repositories;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(string username, string password)
        {
            if (_userRepository.GetByUsername(username) != null)
            {
                return null;
            }

            var user = new User
            {
                Username = username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };
            _userRepository.Create(user);
            return user;
        }

        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
