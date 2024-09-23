using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogsAsync();
        Task<Blog> GetBlogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<Blog> UpdateBlogAsync(int id, Blog blog);
        Task<Blog> DeleteBlogAsync(int id);
    }
}
