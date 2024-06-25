using Blog.Domain.Entities;
using Blog.Domain.InterfacesRepositories;
using Blog.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDBContext _context;

        public PostRepository(BlogDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.Include(p => p.User).ToList();
        }

        public Post GetById(int id)
        {
            return _context.Posts.Include(p => p.User).SingleOrDefault(p => p.Id == id);
        }

        public void Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }
    }

}
