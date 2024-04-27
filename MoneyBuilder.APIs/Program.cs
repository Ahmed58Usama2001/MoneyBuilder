

namespace MoneyBuilder.APIs;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Configure services


        builder.Services.AddControllers();

        builder.Services.AddSwaggerServices();

        builder.Services.AddDbContext<MoneyBuilderContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddApplicationServices();

        builder.Services.AddIdentityServices(builder.Configuration);

        builder.Services.AddHttpClient();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy", options =>
            {
                options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
        });

        #endregion


        var app = builder.Build();

        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;

        var _dbContext = services.GetRequiredService<MoneyBuilderContext>();
        ////Ask CLR for creating object from Context explicitly


        var loggerFactory = services.GetRequiredService<ILoggerFactory>();

        try
        {
            await _dbContext.Database.MigrateAsync(); // Update-Database
            //await MultaqaTechContextSeed.SeedAsync(_dbContext); // Data Seeding


            var _userManager = services.GetRequiredService<UserManager<AppUser>>();
            /*await AppIdentityDbContextSeed.SeedUsersAsync(_userManager);*/ // Data Seeding
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogError(ex, "An error occurred during applying the migration.");
        }


        #region Configure Middlewares

        app.UseMiddleware<ExceptionMiddleWare>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerMiddlewares();
        }

        //app.UseMiddleware<RateLimeterMiddleware>();

        app.UseStatusCodePagesWithRedirects("/errors/{0}");

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseCors("MyPolicy");

        app.MapControllers();

        app.UseAuthentication();

        app.UseAuthorization();

        #endregion

        app.Run();
    }
}
