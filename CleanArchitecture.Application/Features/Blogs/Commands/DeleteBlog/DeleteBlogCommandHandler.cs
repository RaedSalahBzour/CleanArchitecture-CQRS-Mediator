using AutoMapper;
using CleanArchitecture.Domain.Repository;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog
{
    internal class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        public DeleteBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            return await _blogRepository.DeleteBlogAsync(request.blogId);
        }
    }
}
