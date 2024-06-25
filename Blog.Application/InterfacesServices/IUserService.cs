using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.InterfacesServices
{
    public interface IUserService
    {
        User Register(string username, string password);
        User Authenticate(string username, string password);
        User GetById(int id);
    }
}
