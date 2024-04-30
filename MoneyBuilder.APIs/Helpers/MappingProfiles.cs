namespace MoneyBuilder.APIs.Helpers;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<LevelCreateDto, Level>()
            .ForMember(dest => dest.PictureUrl, opt => opt.Ignore());
        CreateMap<Level, LevelReturnDto>()
            .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<GenericMediaUrlResolver<Level, LevelReturnDto>>());


        CreateMap<LectureCreateDto, Lecture>()
            .ForMember(dest => dest.VideoUrl, opt => opt.Ignore());
        CreateMap<LectureUpdateDto, Lecture>()
            .ForMember(dest => dest.VideoUrl, opt => opt.Ignore());
        CreateMap<Lecture, LectureReturnDto>()
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level.Title))
            .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom<GenericMediaUrlResolver<Lecture, LectureReturnDto>>());

        CreateMap<QuestionCreateDto, Question>();
        CreateMap<QuestionUpdateDto, Question>();
        CreateMap<Question, QuestionReturnDto>();

        CreateMap<AnswerCreateDto, Answer>();
        CreateMap<Answer, AnswerReturnDto>();




    }
}