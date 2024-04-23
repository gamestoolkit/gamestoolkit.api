using Dapper;
using gamestoolkit.api.Models;
using System.Data;

namespace gamestoolkit.api.Repositories.Dapper
{
    public class PostRepository : IPostRepository
    {
        private GTKDapperContext _context;
        public PostRepository(GTKDapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePostAsync(Post newPost)
        {
            var query = @"
                INSERT INTO Posts (Title, Description, Author, ContentHtml, PostImage)
                VALUES (@Title, @Description, @Author, @ContentHtml, @PostImage)
                RETURNING id";

            var parameters = new DynamicParameters();
            parameters.Add("Title", newPost.Title, DbType.String);
            parameters.Add("Description", newPost.Description, DbType.String);
            parameters.Add("Author", newPost.Author, DbType.String);
            parameters.Add("ContentHtml", newPost.ContentHtml, DbType.String);
            parameters.Add("PostImage", newPost.PostImage, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.ExecuteScalarAsync<int>(query, parameters);

                return id;
            }
        }

        public async Task<List<Post>> GetAllPostsAsync()
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
                var posts = await connection.QueryAsync<Post>(query, parameters);

                return posts.ToList();
            }
        }
    }
}
