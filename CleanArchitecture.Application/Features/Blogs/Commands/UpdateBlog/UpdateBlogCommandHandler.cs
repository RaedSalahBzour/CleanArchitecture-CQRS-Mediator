using AutoMapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            //var updateBlog = _mapper.Map<Blog>(request);
            var updateBlog = new Blog() { Id = request.blogId, Name = request.Name, Description = request.Description, Author = request.Author };

            return await _blogRepository.UpdateBlogAsync(request.blogId, updateBlog);
        }
    }
}
