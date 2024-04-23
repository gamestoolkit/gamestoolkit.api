using gamestoolkit.api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamestoolkit.api.Repositories.EF
{
    public class PostRepository : IPostRepository
    {
        private GTKContext _context;
        public PostRepository(GTKContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePostAsync(Post newPost)
        {
            var entity = await _context.Posts.AddAsync(newPost);
            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }
    }
}
