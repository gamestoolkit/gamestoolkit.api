using AutoMapper;
using gamestoolkit.api.Repositories;
using gamestoolkit.api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace gamestoolkit.api.Queries.EF
{
    public class PostQueries : IPostQueries
    {
        private readonly GTKContext _context;
        private readonly IMapper _mapper;
        public PostQueries(GTKContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<List<PostWithoutContent>>> GetAllPostsWithoutContentAsync()
        {
            return new Response<List<PostWithoutContent>> { 
                Content = _mapper.Map<List<PostWithoutContent>>(await _context.Posts.AsNoTracking().ToListAsync()),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }

        public async Task<Response<PostWithContent>> GetPostByIdAsync(int id)
        {
            return new Response<PostWithContent> { 
                Content = _mapper.Map<PostWithContent>(await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
