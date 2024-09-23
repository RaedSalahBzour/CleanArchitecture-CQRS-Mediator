using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog
{
    public record DeleteBlogCommand : IRequest<int>
    {
        public int blogId { get; set; }
    }
}
