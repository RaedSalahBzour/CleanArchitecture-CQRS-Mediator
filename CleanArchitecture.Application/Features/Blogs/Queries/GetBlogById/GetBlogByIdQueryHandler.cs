using AutoMapper;
using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitecture.Domain.Repository;
using MediatR;
namespace CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDto>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetBlogByIdAsync(request.blogId);
            return _mapper.Map<BlogDto>(blog);
        }
    }
}
