namespace MoneyBuilder.Core.Services.Contract.AuthDomainContracts;

public interface IAuthService
{
    Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
}
