using gamestoolkit.api.ViewModels;

namespace gamestoolkit.api.Queries
{
    public interface IPostQueries
    {
        public Task<List<PostWithoutContent>> GetAllPostsWithoutContentAsync();

        public Task<PostWithoutContent> GetPostByIdAsync(int id);
    }
}
