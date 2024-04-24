using gamestoolkit.api.Models;

namespace gamestoolkit.api.Repositories
{
    public interface IPostRepository
    {
        public Task<int> CreatePostAsync(Post newPost);
        public Task UpdatePostAsync(Post post);
        public Task<Post?> GetPostByIdAsync(int id);
        public Task DeletePostAsync(Post postToDelete);
    }
}
