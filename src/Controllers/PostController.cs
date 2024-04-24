using gamestoolkit.api.Commands;
using gamestoolkit.api.Common;
using gamestoolkit.api.Models;
using gamestoolkit.api.Queries;
using gamestoolkit.api.Services;
using gamestoolkit.api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace gamestoolkit.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
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

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PostWithoutContent>> GetByIdAsync(int id)
        {
            var post = await _postQueries.GetPostByIdAsync(id);
            if (post is null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePostCommand createPostCommand)
        {
            var response = await _postServices.CreatePostAsync(createPostCommand);
            return response.GetRestResponse(this);
           /* return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = response.Id },
                response);*/
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdatePostCommand updatePostCommand)
        {
            var response = await _postServices.UpdatePostAsync(id, updatePostCommand);
            return response.GetRestResponse(this);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var response = await _postServices.DeletePostAsync(id);
            return response.GetRestResponse(this);
        }
    }
}
