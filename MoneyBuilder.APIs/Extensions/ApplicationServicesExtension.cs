namespace MoneyBuilder.APIs.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        services.AddScoped(typeof(ILevelService), typeof(LevelService));
        services.AddScoped(typeof(ILectureService), typeof(LectureService));
        services.AddScoped(typeof(IQuestionService), typeof(QuestionService));
        services.AddScoped(typeof(IAnswerService), typeof(AnswerService));
        services.AddScoped(typeof(IProgressService), typeof(ProgressService));

        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddHttpClient();

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = (actionContext) =>
            {
                var errors = actionContext.ModelState.Where(p => p.Value?.Errors.Count() > 0)
                .SelectMany(p => p.Value?.Errors ?? new())
                .Select(e => e.ErrorMessage)
                .ToArray();

                var validationErrorResponse = new ApiValidationErrorResponse()
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(validationErrorResponse);
            };
        });


        return services;
    }
}
