namespace MoneyBuilder.Core.Services.Contract;

public interface IAuthService
{
    Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
}
