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
            CreateMap<Post, PostWithContent>();
            #endregion

            #region Commands
            CreateMap<CreatePostCommand, Post>();
            CreateMap<UpdatePostCommand, Post>();
            #endregion
        }
    }
}
