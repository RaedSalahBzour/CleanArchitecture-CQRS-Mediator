using CleanArchitecture.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogDto>>
    {
        private readonly IBlogRepository blogRepository;

        public GetBlogsQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public async Task<List<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await blogRepository.GetAllBlogsAsync();
            var blogList = blogs.Select(x => new BlogDto
            {
                Id = x.Id,
                Name = x.Name,
                Author = x.Author,
                Description = x.Description
            }).ToList();
            return blogList;
        }
    }
}
