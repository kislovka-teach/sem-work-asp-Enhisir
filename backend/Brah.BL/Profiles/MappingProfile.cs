using AutoMapper;
using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Responses;
using Brah.BL.Dtos.Responses.Article;
using Brah.BL.Dtos.Responses.Resume;
using Brah.Data.Models;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;

namespace Brah.BL.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<Topic, TopicDto>().ReverseMap();
        CreateMap<ArticleTag, TagDto>().ReverseMap();
        CreateMap<ResumeTag, TagDto>().ReverseMap();
        CreateMap<WorkPlace, WorkPlaceDto>().ReverseMap();

        CreateMap<Article, ArticleShortResponseDto>();
        CreateMap<Article, ArticleFullResponseDto>();
        CreateMap<Article, ArticleThumbnailResponseDto>();
        CreateMap<Commentary, CommentaryResponseDto>();

        CreateMap<Resume, ResumeShortResponseDto>();
        CreateMap<Resume, ResumeFullResponseDto>();
    }
}