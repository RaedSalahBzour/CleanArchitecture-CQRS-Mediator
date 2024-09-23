using AutoMapper;
using CleanArchitecture.Domain.Repository;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public GetBlogsQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            var blogList = _mapper.Map<List<BlogDto>>(blogs);
            return blogList;
        }
    }
}
