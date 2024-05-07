using System.Globalization;
using AutoMapper;
using Brah.BL.Dtos.Meta;
using Brah.BL.Dtos.Requests.Auth;
using Brah.BL.Dtos.Requests.Profile;
using Brah.BL.Dtos.Requests.Resume;
using Brah.BL.Dtos.Responses;
using Brah.BL.Dtos.Responses.Article;
using Brah.BL.Dtos.Responses.Resume;
using Brah.Data.Enums;
using Brah.Data.Models;
using Brah.Data.Models.Articles;
using Brah.Data.Models.Resumes;
using Brah.Data.Models.Tags;

namespace Brah.BL.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, UserThumbnailDto>();
        CreateMap<User, ProfileResponseDto>()
            .ForMember(dest => dest.HasResume,
                opt => opt.MapFrom(src => src.Resume != null));
        CreateMap<RegisterRequestDto, User>()
            .ForMember(dest => dest.Role,
                opt => opt.MapFrom(src => Role.User));
        CreateMap<EditProfileRequestDto, User>()
            .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));;

        CreateMap<Topic, TopicDto>();
        CreateMap<ArticleTag, TagDto>().ReverseMap();
        CreateMap<ResumeTag, TagDto>().ReverseMap();
        CreateMap<CreateTagDto, ArticleTag>();
        CreateMap<CreateTagDto, ResumeTag>();
        
        CreateMap<WorkPlace, WorkPlaceDto>()
            .ForMember(
                dest => dest.DateBegin,
                opt => opt.MapFrom(src => src.DateBegin.ToLocalTime().ToString("MM/dd/yyyy")))
            .ForMember(
                dest => dest.DateEnd,
                opt => opt.MapFrom(src => src.DateEnd == null
                    ? null
                    : src.DateEnd.Value.ToLocalTime().ToString("MM/dd/yyyy")));
        CreateMap<CreateWorkPlaceDto, WorkPlace>()
            .ForMember(
                dest => dest.DateBegin, 
                opt => opt.MapFrom(src => DateTime.ParseExact(src.DateBegin, "MM.dd.yyyy", CultureInfo.InvariantCulture).ToUniversalTime()))
            .ForMember(
                dest => dest.DateEnd, 
                opt => opt.MapFrom<DateTime?>(
                    src => src.DateEnd != null
                        ? DateTime.ParseExact(src.DateEnd, "MM.dd.yyyy", CultureInfo.InvariantCulture).ToUniversalTime() 
                        : null));
        CreateMap<UpdateWorkPlaceDto, WorkPlace>()
            .ForMember(
                dest => dest.DateBegin, 
                opt => opt.MapFrom(src => DateTime.Parse(src.DateBegin).ToUniversalTime()))
            .ForMember(
                dest => dest.DateEnd, 
                opt => opt.MapFrom<DateTime?>(
                    src => src.DateEnd != null
                        ? DateTime.Parse(src.DateEnd).ToUniversalTime() 
                        : null));
        
        CreateMap<Article, ArticleShortResponseDto>()
            .ForMember(
                dest => dest.Text,
                opt => opt.MapFrom(src =>
                    src.Text.Length >= 200 ? $"{src.Text.Substring(0, 197)}..." : src.Text));
        CreateMap<Article, ArticleFullResponseDto>();
        CreateMap<Article, ArticleThumbnailResponseDto>();
        CreateMap<Commentary, CommentaryResponseDto>();

        CreateMap<Resume, ResumeShortResponseDto>()
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(
                dest => dest.AvatarLink,
                opt => opt.MapFrom(src => src.User.AvatarLink))
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.User.UserName));
        CreateMap<Resume, ResumeFullResponseDto>()
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(
                dest => dest.AvatarLink,
                opt => opt.MapFrom(src => src.User.AvatarLink))
            .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.User.UserName));

        CreateMap<CreateResumeRequestDto, Resume>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.WorkPlaces, opt => opt.Ignore());
        CreateMap<UpdateResumeRequestDto, Resume>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.WorkPlaces, opt => opt.Ignore());
    }
}