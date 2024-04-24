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

        public async Task<List<PostWithoutContent>> GetAllPostsWithoutContentAsync()
        {
            return _mapper.Map<List<PostWithoutContent>>(await _context.Posts.AsNoTracking().ToListAsync());
        }

        public async Task<PostWithContent> GetPostByIdAsync(int id)
        {
            return _mapper.Map<PostWithContent>(await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
