using Dapper;
using gamestoolkit.api.Repositories;
using gamestoolkit.api.ViewModels;

namespace gamestoolkit.api.Queries.Dapper
{
    public class PostQueries : IPostQueries
    {
        private GTKDapperContext _context;
        public PostQueries(GTKDapperContext context)
        {
            _context = context;
        }
        public async Task<List<PostWithoutContent>> GetAllPostsWithoutContentAsync()
        {
            var query = @"
                SELECT 
                    Id,
                    Title,
                    Description,
                    Author,
                    PostImage
                FROM Posts";

            var parameters = new DynamicParameters();

            using (var connection = _context.CreateConnection())
            {
                var posts = await connection.QueryAsync<PostWithoutContent>(query, parameters);

                return posts.ToList();
            }
        }
    }
}
