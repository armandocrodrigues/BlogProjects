using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.InterfacesServices
{
    public interface IAuthService
    {
        User Register(string username, string password);
        User Login(string username, string password);
    }
}
