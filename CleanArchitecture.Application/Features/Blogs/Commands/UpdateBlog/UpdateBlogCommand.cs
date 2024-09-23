using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog
{
    public record UpdateBlogCommand : IRequest<int>
    {
        public int blogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
