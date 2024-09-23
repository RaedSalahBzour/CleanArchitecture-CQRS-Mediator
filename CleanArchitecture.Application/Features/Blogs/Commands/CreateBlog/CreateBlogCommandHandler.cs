using AutoMapper;
using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogDto>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<BlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = _mapper.Map<Blog>(request);
            var result = await _blogRepository.CreateBlogAsync(blogEntity);
            return _mapper.Map<BlogDto>(result);
        }
    }
}
