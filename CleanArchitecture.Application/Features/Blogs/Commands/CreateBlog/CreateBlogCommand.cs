using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog
{
    public record CreateBlogCommand : IRequest<BlogDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
