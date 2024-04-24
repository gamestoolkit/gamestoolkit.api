using gamestoolkit.api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace gamestoolkit.api.Repositories
{
    public class GTKContext : DbContext
    {        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<PostCollection> PostCollections { get; set; }

        public GTKContext(DbContextOptions<GTKContext> options) : base(options)
        {

        }
    }

    public class GTKDapperContext
    {
        private readonly IConfiguration _configuration = null!;
        private readonly string _connectionString = null!;

        public GTKDapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
