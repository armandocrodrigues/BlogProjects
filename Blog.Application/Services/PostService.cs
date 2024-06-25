using Blog.Application.InterfacesServices;
using Blog.Domain.Entities;
using Blog.Domain.InterfacesRepositories;
using Microsoft.AspNetCore.SignalR;
using Blog.Infra.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Notification;

namespace Blog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public PostService(IPostRepository postRepository, IHubContext<NotificationHub> hubContext)
        {
            _postRepository = postRepository;
            _hubContext = hubContext;
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }

        public Post Create(Post post)
        {
            post.CreatedAt = DateTime.UtcNow;
            _postRepository.Create(post);
            _hubContext.Clients.All.SendAsync("ReceiveNotification", post);
            return post;
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }
    }
}
