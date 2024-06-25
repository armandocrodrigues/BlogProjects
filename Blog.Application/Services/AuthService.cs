using Blog.Application.InterfacesServices;
using Blog.Domain.Entities;
using Blog.Domain.InterfacesRepositories;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

       /* public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(string username, string password)
        {
            var existingUser = _userRepository.GetByUsername(username);
            if (existingUser != null)
            {
                throw new Exception("Username already taken");
            }

            var user = new User
            {
                Username = username,
                //PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
            };

            _userRepository.Create(user);
            return user;
        }

        public User Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            /*if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                throw new Exception("Invalid credentials");
            }

            return user;*/
        
    }

}
