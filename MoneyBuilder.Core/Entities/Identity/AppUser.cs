namespace MoneyBuilder.Core.Entities.Identity;

public class AppUser : IdentityUser
{
    public UserProgress UserProgress { get; set; }
}