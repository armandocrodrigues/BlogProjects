using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.InterfacesServices
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        Post Create(Post post);
        void Update(Post post);
        void Delete(int id);
    }
}
