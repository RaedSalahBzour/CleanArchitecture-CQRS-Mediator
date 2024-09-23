using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _dbContext;

        public BlogRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await _dbContext.Blogs.AddAsync(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            return await _dbContext.Blogs.Where(model => model.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _dbContext.Blogs.FindAsync(id);

        }

        public async Task<int> UpdateBlogAsync(int id, Blog blog)
        {
            return await _dbContext.Blogs.Where(model => model.Id == id)
                   .ExecuteUpdateAsync(setters => setters
                   .SetProperty(m => m.Id, blog.Id)
                   .SetProperty(m => m.Name, blog.Name)
                   .SetProperty(m => m.Author, blog.Author)
                   .SetProperty(m => m.Description, blog.Description));
        }
    }
}
