using AutoMapper;
using Brah.BL.Dtos.Responses;
using Brah.BL.Dtos.Responses.Article;
using Brah.Data.Models.Articles;

namespace Brah.BL.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Article, ArticleShortResponseDto>();
        CreateMap<Article, ArticleFullResponseDto>();
    }
}