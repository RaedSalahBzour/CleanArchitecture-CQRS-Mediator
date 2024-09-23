using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById
{
    public record GetBlogByIdQuery : IRequest<BlogDto>
    {
        public int blogId { get; set; }
    }
}
