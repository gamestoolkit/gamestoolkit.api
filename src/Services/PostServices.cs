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

        public async Task<NoContentResponse> UpdatePostAsync(int id, UpdatePostCommand updatePostCommand)
        {
            var post = _mapper.Map<Post>(updatePostCommand);
            var oldPost = await _postRepository.GetPostByIdAsync(id);
            if (oldPost is null)
            {
                return new NoContentResponse { StatusCode = System.Net.HttpStatusCode.NotFound };
            }

            post.Id = oldPost.Id;
            post.Author ??= oldPost.Author;
            post.Description ??= oldPost.Description;
            post.Title ??= oldPost.Title;
            post.ContentHtml ??= oldPost.ContentHtml;
            post.PostImage ??= oldPost.PostImage;

            await _postRepository.UpdatePostAsync(post);

            return new NoContentResponse { StatusCode = System.Net.HttpStatusCode.NoContent };
        }

        public async Task<NoContentResponse> DeletePostAsync(int id)
        {            
            var postToDelete = await _postRepository.GetPostByIdAsync(id);
            if (postToDelete is null)
            {
                return new NoContentResponse { StatusCode = System.Net.HttpStatusCode.NotFound };
            }

            await _postRepository.DeletePostAsync(postToDelete);

            return new NoContentResponse { StatusCode = System.Net.HttpStatusCode.NoContent };
        }
    }
}
