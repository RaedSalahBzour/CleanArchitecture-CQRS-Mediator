using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs
{
    public record GetBlogsQuery : IRequest<List<BlogDto>>
    {

    }
}
