using AutoMapper;
using gamestoolkit.api.Commands;
using gamestoolkit.api.Mappings;
using gamestoolkit.api.Models;
using gamestoolkit.api.Repositories;
using gamestoolkit.api.Services;
using Moq;

namespace gamestoolkit.tests.Unit
{
    public class PostServicesTests
    {
        static private int VALID_ID = 1;
        static string VALID_HTML = "<html>";
        static string INVALID_HTML = "just an example how to mock diff results according to inputs.";


        private Mock<IPostRepository> GetRepositoryMock()
        {
            // This shows how to create a mock that reacts differently according to input params.
            var repositoryMock = new Mock<IPostRepository>();
            repositoryMock
                .Setup(r => r.CreatePostAsync(It.Is<Post>(p => p.ContentHtml == VALID_HTML)))
                .ReturnsAsync(VALID_ID);
            repositoryMock
                .Setup(r => r.CreatePostAsync(It.Is<Post>(p => p.ContentHtml == INVALID_HTML)))
                .ThrowsAsync(new Exception());

            return repositoryMock;
        }

        private IMapper GetAutomapper()
        {
            var myProfile = new PostMappings();
            var configuration = new MapperConfiguration(c => c.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            return mapper;
        }

        private CreatePostCommand GetCommand(bool isValid) => new CreatePostCommand
        {
            Title = "Title",
            Author = "Author",
            ContentHtml = isValid ? VALID_HTML : INVALID_HTML,
        };

        [Fact]
        public async Task Create_Ok()
        {
            // Prepare
            var repositoryMock = GetRepositoryMock();
            var service = new PostServices(repositoryMock.Object, GetAutomapper());
            var command = GetCommand(true);

            // Test
            var result = await service.CreatePostAsync(command);

            // Check
            Assert.NotNull(result);
            Assert.Equal(VALID_ID, result.Id);
            repositoryMock.Verify(m => m.CreatePostAsync(It.IsAny<Post>()), Times.Exactly(1));
        }

        [Fact]
        public async Task Create_BadHtml_Fails()
        {
            // Following case is just an illustrative example
            // There is now real reason to fail by using the string INVALID_HTML
            
            // Prepare
            var repositoryMock = GetRepositoryMock();
            var service = new PostServices(repositoryMock.Object, GetAutomapper());
            var command = GetCommand(false);

            // Test
            await Assert.ThrowsAsync<Exception>(
                () => service.CreatePostAsync(command)
            );
        }
    }
}
