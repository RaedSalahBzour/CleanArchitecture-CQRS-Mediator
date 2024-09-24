using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsunc()
        {
            var blogs = await mediator.Send(new GetBlogsQuery());
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await mediator.Send(new GetBlogByIdQuery() { blogId = id });
            if (blog is null)
            {
                return NotFound();
            }
            return Ok(blog);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            var createdBlog = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, UpdateBlogCommand command)
        {
            if (id != command.blogId)
            {
                return NotFound();
            }
            await mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await mediator.Send(new DeleteBlogCommand() { blogId = id });
            return Ok();
        }
    }
}
