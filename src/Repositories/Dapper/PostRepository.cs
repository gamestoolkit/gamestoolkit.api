using Dapper;
using gamestoolkit.api.Models;
using gamestoolkit.api.ViewModels;
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
                OUTPUT INSERTED.Id 
                VALUES (@Title, @Description, @Author, @ContentHtml, @PostImage)";

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

        public async Task DeletePostAsync(Post postToDelete)
        {
            var query = @"
                DELETE FROM Posts
                WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", postToDelete.Id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
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

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            var query = @"
                SELECT 
                    Id,
                    Title,
                    Description,
                    Author,
                    PostImage,
                    ContentHtml
                FROM Posts
                WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                var post = await connection.QuerySingleOrDefaultAsync<Post>(query, parameters);

                return post;
            }
        }

        public async Task UpdatePostAsync(Post post)
        {
            var query = @"
                UPDATE Posts
                SET Title = @Title, 
                    Description = @Description,
                    Author = @Author,
                    ContentHtml = @ContentHtml,
                    PostImage = @PostImage 
                WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Title", post.Title, DbType.String);
            parameters.Add("Description", post.Description, DbType.String);
            parameters.Add("Author", post.Author, DbType.String);
            parameters.Add("ContentHtml", post.ContentHtml, DbType.String);
            parameters.Add("PostImage", post.PostImage, DbType.String);
            parameters.Add("Id", post.Id, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
