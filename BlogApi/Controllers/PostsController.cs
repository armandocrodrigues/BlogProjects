using Blog.Application.InterfacesServices;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostsController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Post post)
        {
            var user = _userService.GetById(post.UserId);
            if (user == null)
            {
                return BadRequest("Invalid user");
            }
            var createdPost = _postService.Create(post);
            return Ok(createdPost);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Post post)
        {
            var existingPost = _postService.GetById(id);
            if (existingPost == null)
            {
                return NotFound();
            }
            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            _postService.Update(existingPost);
            return Ok(existingPost);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _postService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            _postService.Delete(id);
            return NoContent();
        }
    }

}
