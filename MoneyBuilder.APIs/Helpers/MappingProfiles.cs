
namespace MoneyBuilder.APIs.Helpers;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<LevelCreateDto, Level>()
            .ForMember(dest => dest.PictureUrl, opt => opt.Ignore());

        CreateMap<Level, LevelReturnDto>()
            .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<GenericMediaUrlResolver<Level, LevelReturnDto>>());
    }
}