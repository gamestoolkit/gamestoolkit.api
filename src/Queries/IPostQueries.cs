using gamestoolkit.api.ViewModels;

namespace gamestoolkit.api.Queries
{
    public interface IPostQueries
    {
        public Task<Response<List<PostWithoutContent>>> GetAllPostsWithoutContentAsync();

        public Task<Response<PostWithContent>> GetPostByIdAsync(int id);
    }
}
