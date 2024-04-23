using AutoMapper;
using gamestoolkit.api.Commands;
using gamestoolkit.api.Models;
using gamestoolkit.api.ViewModels;

namespace gamestoolkit.api.Mappings
{
    public class PostMappings : Profile
    {
        public PostMappings() 
        {
            #region Queries
            CreateMap<Post, PostWithoutContent>();
            #endregion

            #region Commands
            CreateMap<CreatePostCommand, Post>();
            #endregion
        }
    }
}
