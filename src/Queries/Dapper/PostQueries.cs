using Dapper;
using gamestoolkit.api.Repositories;
using gamestoolkit.api.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace gamestoolkit.api.Queries.Dapper
{
    public class PostQueries : IPostQueries
    {
        private GTKDapperContext _context;
        public PostQueries(GTKDapperContext context)
        {
            _context = context;
        }
        public async Task<Response<List<PostWithoutContent>>> GetAllPostsWithoutContentAsync()
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

                return new Response<List<PostWithoutContent>> {
                    Content = posts.ToList(),
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
        }

        public async Task<Response<PostWithContent>> GetPostByIdAsync(int id)
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
                var post = await connection.QuerySingleAsync<PostWithContent>(query, parameters);

                return new Response<PostWithContent> {
                    Content = post,
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
        }
    }
}
