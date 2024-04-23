using gamestoolkit.api.Models;

namespace gamestoolkit.api.Repositories
{
    public interface IPostRepository
    {
        public Task<int> CreatePostAsync(Post newPost); 
    }
}
