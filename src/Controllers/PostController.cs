using gamestoolkit.api.Commands;
using gamestoolkit.api.Models;
using gamestoolkit.api.Queries;
using gamestoolkit.api.Services;
using gamestoolkit.api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace gamestoolkit.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly IPostQueries _postQueries;
        private readonly PostServices _postServices;

        public PostController(IPostQueries postQueries, PostServices postServices)
        {
            _postQueries = postQueries;
            _postServices = postServices;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<PostWithoutContent>>> GetAllAsync()
        {
            return await _postQueries.GetAllPostsWithoutContentAsync();
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<CreationResponse> CreateAsync(CreatePostCommand createPostCommand)
        {
            var response = await _postServices.CreatePostAsync(createPostCommand);
            return CreatedAtAction(
                nameof(GetAllAsync),
                new { },
                response
            );
        }

        [HttpPut]
        public IActionResult UpdateAsync()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
