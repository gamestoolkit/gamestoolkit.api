using AutoMapper;
using gamestoolkit.api.Commands;
using gamestoolkit.api.Models;
using gamestoolkit.api.Repositories;
using gamestoolkit.api.ViewModels;

namespace gamestoolkit.api.Services
{
    public class PostServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostServices(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreateResponse> CreatePostAsync(CreatePostCommand createPostCommand)
        {
            var post = _mapper.Map<Post>(createPostCommand);
            var id = await _postRepository.CreatePostAsync(post);
            return new CreateResponse { Id = id };
        }
    }
}
